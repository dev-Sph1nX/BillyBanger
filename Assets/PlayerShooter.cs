using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Transform cameraTransform;
    void Awake()
    {
        InputController.instance.onLeftClickClicked += this.Fire;
    }

    void Update()
    {
        Debug.DrawRay(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
    }

    void Fire()
    {

        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.tag == "Target")
            {
                Target target = hit.transform.gameObject.GetComponent<Target>();
                target?.Hit();
            }
        }
    }
}
