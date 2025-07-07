using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public float cameraSpeed;

    // Update is called once per frame
    void Update()
    {
        // moving camera up the y axis
        transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);

    }
}
