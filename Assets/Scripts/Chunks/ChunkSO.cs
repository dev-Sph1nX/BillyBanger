using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Chunk", menuName = "Chunk")]
public class ChunkSO : ScriptableObject
{
    public GameObject chunkVariant;
    public float length = 200;
    public float width = 80;
}
