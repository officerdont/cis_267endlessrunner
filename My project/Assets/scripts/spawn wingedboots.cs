using UnityEngine;

public class spawnwingedboots : MonoBehaviour
{
    public GameObject wingedbootsprefab;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawns;
    private float spawntimer;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawntimer)
        {
            Spawn();
            spawntimer = Time.time + timeBetweenSpawns;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(wingedbootsprefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

    }
}
