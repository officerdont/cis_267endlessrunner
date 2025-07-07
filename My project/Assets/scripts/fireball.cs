using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fireball : MonoBehaviour
{
    public float cameraSpeed;
    public float ymovement;
    
    

    // Update is called once per frame
    void Update()
    {
       // move across screen
               transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
             transform.position += new Vector3(0, ymovement * Time.deltaTime, 0);

        // staying on the same y axis



        // destroy fireball after 2 seconds

    }
}
