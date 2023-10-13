using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Tooltip("Will be set by ChunkController on instantiate.")]
    public ChunkSO chunkSO;
    public List<GameObject> targets;

    public void Init(int nbTargets)
    {
        List<GameObject> selectedTargets = targets.OrderBy(arg => Guid.NewGuid()).Take(nbTargets).ToList();
        foreach (GameObject selected in selectedTargets)
        {
            selected.SetActive(true);
        }
    }

    void Update()
    {
        if (this.transform.localPosition.z < -chunkSO.length)
        {
            Destroy(gameObject);
        }
    }
}
