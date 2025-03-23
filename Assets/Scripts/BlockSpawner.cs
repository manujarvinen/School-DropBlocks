using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockSource; // Should not be static
    private float timer = 0f;
    public int spawnInterval = 3;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnBlock();
            timer = 0f; // Reset the timer
        }
    }

    public void SpawnBlock()
    {
        if (blockSource != null) // Prevent NullReferenceException
        {
            float randomX = Random.Range(-transform.localScale.x / 2f, transform.localScale.x / 2f); // Generate a new random value each time
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
            Instantiate(blockSource, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("BlockSource is not assigned!");
        }
    }
}
