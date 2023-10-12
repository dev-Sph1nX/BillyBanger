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

    public float chunkSpawnX;
    public float chunkDespawnX;
    public float chunkScale = 30;
    public float chunkSpeed = 10;
    public int chunkNbTargets = 4;

    public List<ChunkSO> chunksSO;
    private Chunk _currentChunk;
    private Chunk _previousChunkSpawn;
    private int _chunkIndex = 0;
    private float _totalDistance = 0;
    private bool _stopSpawning = false;
    private float quartTemps;

    void Start()
    {
        this.quartTemps = GameController.Instance.globalGameTime / chunkNbTargets;
    }

    public void StartChunkSpawning()
    {
        CreateChunk(chunksSO[_chunkIndex]);
    }

    public void CreateChunk(ChunkSO newChunkSO, float offset = 0)
    {
        if (_chunkIndex + 1 >= chunksSO.Count) _chunkIndex = 0;
        else _chunkIndex++;

        _previousChunkSpawn = _currentChunk;

        _currentChunk = GameObject.Instantiate(GameController.Instance.ChunkPrefab);
        if (!_previousChunkSpawn) _previousChunkSpawn = _currentChunk; // on first spawn

        _currentChunk.chunkSO = newChunkSO;
        _currentChunk.transform.localPosition = new Vector3(chunkSpawnX - offset, 0, chunkScale / 2);

        int nbTargets = 1;
        while (nbTargets < chunkNbTargets && Time.timeSinceLevelLoad > quartTemps * nbTargets)
        {
            nbTargets++;
        }
        _currentChunk.Init(nbTargets);
    }

    void Update()
    {
        _totalDistance += Time.deltaTime * chunkSpeed;
        if (_totalDistance >= chunkScale && !_stopSpawning)
        {
            _totalDistance = _totalDistance - chunkScale; // = offset
            CreateChunk(chunksSO[_chunkIndex], _totalDistance);
        }
    }

    public void StopChunkSpawning()
    {
        _stopSpawning = true;
    }
}
