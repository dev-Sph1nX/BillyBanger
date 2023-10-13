using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour
{
    private static ChunkController _instance;
    public static ChunkController Instance
    {
        get
        {
            if (ChunkController._instance == null)
                ChunkController._instance = FindObjectOfType<ChunkController>();

            return ChunkController._instance;
        }
    }

    [Range(0, 20)]
    public float chunkSpeed = 0;

    public int nbStateDifficulties = 4;

    public List<ChunkSO> chunksSO;

    private Chunk _currentChunk;
    private Chunk _previousChunkSpawn;
    private int _chunkIndex = 0;
    private float _totalDistance = 0;
    private float quartTemps;
    private float previousSpeed;

    private int _remainingChunks = 9999;

    void Awake()
    {
        this.previousSpeed = chunkSpeed;
        this.quartTemps = GameController.Instance.globalGameTime / nbStateDifficulties;
    }

    public void StartChunkSpawning()
    {
        CreateChunk(chunksSO[_chunkIndex]);
        StartCoroutine(IncreaseSpeed());
    }

    public void CreateChunk(ChunkSO newChunkSO, float offset = 0, bool noTarget = false)
    {
        if (_chunkIndex + 1 >= chunksSO.Count) _chunkIndex = 0;
        else _chunkIndex++;

        _previousChunkSpawn = _currentChunk;

        GameObject newgo = GameObject.Instantiate(newChunkSO.chunkVariant);
        _currentChunk = newgo.GetComponent<Chunk>();
        if (!_previousChunkSpawn) _previousChunkSpawn = _currentChunk; // on first spawn

        _currentChunk.chunkSO = newChunkSO;
        _currentChunk.transform.localPosition = new Vector3(-newChunkSO.width - offset, 0, newChunkSO.length);

        int nbTargets = _currentChunk.targets.Count / nbStateDifficulties;
        for (int i = 0; i < nbStateDifficulties; i++)
        {
            if (Time.timeSinceLevelLoad >= quartTemps * i)
            {
                nbTargets += _currentChunk.targets.Count / nbStateDifficulties;
            }
        }
        if (noTarget) nbTargets = 0;
        _currentChunk.Init(nbTargets);
        _remainingChunks--;
    }

    void Update()
    {
        _totalDistance += Time.deltaTime * chunkSpeed;
        if (_totalDistance >= chunksSO[_chunkIndex].length && _remainingChunks > 0)
        {
            _totalDistance = _totalDistance - chunksSO[_chunkIndex].length; // = offset
            CreateChunk(chunksSO[_chunkIndex], _totalDistance, _remainingChunks == 1);
        }
    }

    public void StopChunkSpawning()
    {
        Debug.Log("StopChunkSpawning");
        _remainingChunks = 1;

    }

    public void SlowSpeed(float factor)
    {
        previousSpeed = chunkSpeed;
        chunkSpeed = chunkSpeed * factor;
    }

    public void ResetSpeed()
    {
        chunkSpeed = previousSpeed;
    }

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            if (chunkSpeed < 10)
            {
                chunkSpeed += 0.4f;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
