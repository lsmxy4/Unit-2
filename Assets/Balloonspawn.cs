using UnityEngine;

public class BalloonSpawn : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float spawnInterval = 2f;

    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 2f;

    void Start()
    {
        InvokeRepeating("SpawnBalloon", 1f, spawnInterval);
    }

    void SpawnBalloon()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        if (balloonPrefab != null)
        {
            Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
        }
    }


    void Update()
    {
        
    }
}
