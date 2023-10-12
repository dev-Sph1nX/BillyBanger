using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chunk", menuName = "Chunk")]
public class ChunkSO : ScriptableObject
{
    public int scale = 30;
    public Material groundMaterial;
}
