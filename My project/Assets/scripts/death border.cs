using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathborder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject)
        {
            Destroy(collision.gameObject);
        }
    }
}
