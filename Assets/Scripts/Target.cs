using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 20;
    public MeshRenderer meshRenderer;
    public Material hitMaterial;
    public void Hit()
    {
        //meshRenderer.material = hitMaterial;
        Destroy(this.gameObject);
        GameController.Instance.ScorePoint(points);
    }
}
