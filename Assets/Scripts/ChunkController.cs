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
    public List<ChunkSO> chunksSO;

    private Chunk currentChunk;
    private Chunk previousChunkSpawn;

    void Start()
    {
        CreateChunk(chunksSO[0]);
    }

    public void CreateChunk(ChunkSO newChunkSO)
    {
        previousChunkSpawn = currentChunk;

        currentChunk = GameObject.Instantiate(GameController.Instance.ChunkPrefab);
        if (!previousChunkSpawn) previousChunkSpawn = currentChunk; // on first spawn

        currentChunk.chunkSO = newChunkSO;
        currentChunk.transform.localPosition = new Vector3(newChunkSO.scale, 0, newChunkSO.scale / 2);
    }


    void Update()
    {
        Debug.Log(previousChunkSpawn);
        if (previousChunkSpawn.transform.localPosition.x < 0)
        {
            CreateChunk(chunksSO[0]);
        }
    }
}
