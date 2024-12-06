using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BuildingLighting : MonoBehaviour
{
    public Volume[] interiorVolumes; // Assign the Volumes here in the Inspector
    public GameObject roof; // Assign the roof here in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Volume volume in interiorVolumes)
            {
                volume.weight = 1.0f; // Activate interior lighting
            }
            Debug.Log("Player entered the building.");
            roof.SetActive(false); // Hide the roof
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Volume volume in interiorVolumes)
            {
                volume.weight = 0.0f; // Deactivate interior lighting
            }
            Debug.Log("Player exited the building.");
            roof.SetActive(true); // Show the roof
        }
    }
}

