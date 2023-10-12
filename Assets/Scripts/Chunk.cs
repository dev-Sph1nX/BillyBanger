using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Tooltip("Will be set by ChunkController on instantiate.")]
    public ChunkSO chunkSO;
    public MeshRenderer groundMeshRenderer;

    void Start()
    {
        this.groundMeshRenderer.material = this.chunkSO.groundMaterial;
    }

    void Update()
    {

    }
}
