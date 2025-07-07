using UnityEngine;

public class destroyself : MonoBehaviour
{
    private float destroyTime; // time in seconds before destruction
    // destroy prefab after 20 seconds

    private void Update()
    {
        destroyTime += Time.deltaTime;
        if (destroyTime >= 20f)
        {
            Destroy(gameObject);
        }

    }
}
