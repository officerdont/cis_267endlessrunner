using Unity.VisualScripting;
using UnityEngine;

public class spear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float spearspeed;
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, spearspeed * Time.deltaTime, 0);

        
          
        

    }
}
