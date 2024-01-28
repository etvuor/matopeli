using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private float spawnrate = 1f;
    [SerializeField] private GameObject[] prefabs;

    [SerializeField] private bool canSpawn = true;

    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnrate);

        while (canSpawn)  // You can add a condition for when to stop spawning
        {
            yield return wait;

            // Generate a random x position between the left and right edges
            float randomX = Random.Range(leftEdge.position.x, rightEdge.position.x);

            // Set the y position to the spawner's y position
            float yPosition = transform.position.y;

            int rand = Random.Range(0, prefabs.Length);
            GameObject enemyToSpawn = prefabs[rand];

            // Instantiate the enemy with the random position
            Instantiate(enemyToSpawn, new Vector3(randomX, yPosition, transform.position.z), Quaternion.identity);
        }
    }
}
