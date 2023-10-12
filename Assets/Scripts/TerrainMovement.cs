using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    [Range(0, 50)]
    [Tooltip("Vitesse de translation du terrain")]
    public float speed;

    void Update()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * speed / GameController.Instance.speedFactor, Space.Self);
    }

}
