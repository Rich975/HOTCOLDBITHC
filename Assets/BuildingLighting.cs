using UnityEngine;
using UnityEngine.Rendering;

public class BuildingLighting : MonoBehaviour
{
    public Volume[] interiorVolumes; // Assign the Volumes here in the Inspector
    public GameObject roof; // Assign the roof here in the Inspector
    public Light sunLight;

    private void Start()
    {
    }

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

        if (sunLight != null)
        {
            sunLight.shadows = LightShadows.None;
            Debug.Log("Sun shadows disabled.");
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

        if (sunLight != null)
        {
            sunLight.shadows = LightShadows.Hard;
            Debug.Log("Sun shadows enabled.");
        }
    }
}