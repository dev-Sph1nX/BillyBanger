using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material hitMaterial;
    public void Hit()
    {
        meshRenderer.material = hitMaterial;
    }
}
