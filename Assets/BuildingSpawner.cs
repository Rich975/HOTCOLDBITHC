using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject ground; // Assign the ground object in the Inspector
    public GameObject target;
    public GameObject player;

    public GameObject objectToSpawn; // Assign the prefab to spawn
    public int numberOfObjects = 10; // Number of objects to spawn

    private float yOffset = 2.4f;

    public List<Quaternion> quaternions = new List<Quaternion>();
    [SerializeField] private Quaternion noRot = new Quaternion(0, 0, 0, 0);
    [SerializeField] private Quaternion ninetyRot = new Quaternion(0, 90, 0, 0);
    [SerializeField] private Quaternion oneEigthyRot = new Quaternion(0, 180, 0, 0);
    [SerializeField] private Quaternion threeQuaterRot = new Quaternion(0, 270, 0, 0);

    private Bounds groundBounds;

    private void Start()
    {
        quaternions.Add(noRot);
        quaternions.Add(ninetyRot);
        quaternions.Add(oneEigthyRot);
        quaternions.Add(threeQuaterRot);

        // Get the Renderer of the ground
        Renderer groundRenderer = ground.GetComponent<Renderer>();

        if (groundRenderer != null)
        {
            // Get the world bounds of the ground
            groundBounds = groundRenderer.bounds;
            SpawnObjects();
        }
        else
        {
            Debug.LogError("The ground object does not have a Renderer component!");
        }

        SpawnSingleTarget(groundBounds);
    }

    private void Update()
    {
        //GetDistanceToPlayer();
    }

    private void SpawnObjects()
    {
        // Spawn objects within the bounds
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = GetRandomPositionWithinBounds(groundBounds);
            Instantiate(objectToSpawn, spawnPosition, PickRandomRotation());
        }
    }

    private Quaternion PickRandomRotation()
    {
        int randomPick = Random.Range(0, quaternions.Count);
        Debug.Log(randomPick);
        Quaternion objectRotation = quaternions[randomPick];
        return objectRotation;
    }

    private Vector3 GetRandomPositionWithinBounds(Bounds bounds)
    {
        // Generate random X and Z within the bounds
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        // Use the Y position of the ground's center
        float spawnY = bounds.center.y;

        return new Vector3(randomX, yOffset, randomZ);
    }

    private void SpawnSingleTarget(Bounds bounds)
    {
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        Vector3 spawnPosition = new Vector3(randomX, yOffset, randomZ);
        Instantiate(target, spawnPosition, Quaternion.identity);
    }

    public float GetDistanceToPlayer()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(player.transform.position, target.transform.position);
            return distance;    
        } else
        {
            Debug.Log("No target found!");
            return -1;
        }
    }
}