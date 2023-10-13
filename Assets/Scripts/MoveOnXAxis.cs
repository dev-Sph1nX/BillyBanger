using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnXAxis : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition += new Vector3(0, 0, 7.5f * Time.deltaTime);
    }
}
