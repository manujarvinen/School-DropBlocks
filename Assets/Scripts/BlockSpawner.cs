using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockSource; // Prefab to spawn
    private float timer = 0f;
    public float spawnInterval = 3f;
    public Transform blueBall; // Reference to blue ball

    void Update()
    {
        if (spawnInterval >= 1.0f)
        {
            spawnInterval -= Time.deltaTime / 20f; // Decrease interval gradually
        }
        
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBlock();
            timer = 0f; // Reset the timer
        }
    }

    public void SpawnBlock()
    {
        if (blockSource != null)
        {
            float randomX;
            
            // 33% chance to spawn at blueBall's X-position
            if (Random.value < 0.33f && blueBall != null)
            {
                randomX = blueBall.position.x;
            }
            else
            {
                // Otherwise, spawn at a random position in the spawner's range
                randomX = Random.Range(-transform.localScale.x / 2f, transform.localScale.x / 2f);
            }

            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
            Instantiate(blockSource, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("BlockSource is not assigned!");
        }
    }
}
