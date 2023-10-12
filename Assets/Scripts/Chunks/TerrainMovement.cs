using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * (ChunkController.Instance.chunkSpeed * GameController.Instance.speedFactor), Space.Self);
    }

}
