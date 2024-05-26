using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_spawn_script : MonoBehaviour
{
    public GameObject cloud_object;
    public float spawnRate;
    public float heightOffset;
    public int initialCloudCount;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        float screenEdgeCoordinate = 30;
        // Spawn some initial clouds so the game doesn't feel empty
        for(int i = 0; i < initialCloudCount; i++)
        {
            spawnCloud(x_pos: Random.Range(-screenEdgeCoordinate, screenEdgeCoordinate));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnCloud(x_pos: transform.position.x); // spawn at default x coordinate (i.e. start offscreen)
            timer = 0;
        }

    }

    void spawnCloud(float x_pos)
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(cloud_object, new Vector3(x_pos, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
