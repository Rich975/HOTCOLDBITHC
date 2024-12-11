using System.Collections;
using UnityEngine;

public class TargetScanner : MonoBehaviour
{
    public static TargetScanner Ins { get; private set; }


    [SerializeField] private AudioClip sonarAudio;
    private AudioSource audioSource;

    public Transform target;
    public Transform player;

    public float maxDistance = 100f; // Maximum distance for the sonar effect
    public float minInterval = 0.3f; // Minimum interval between sonar pings (fastest rate)
    public float maxInterval = 2f; // Maximum interval between sonar pings (slowest rate)

    private Coroutine sonarCoroutine;

    private void Start()
    {
        Ins = this;

        // Assign target and player if not already set
        target = GameObject.FindGameObjectWithTag("target").GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();

        if (target != null && player != null)
        {
            sonarCoroutine = StartCoroutine(PlaySonarSound());
        }
        else
        {
            //target = target ?? GameObject.FindGameObjectWithTag("target").GetComponent<Transform>();
            Debug.Log("Target or Player not assigned.");
        }
    }

    private void Update()
    {
        //DistanceToTarget();
    }

    private void OnDisable()
    {
        // Stop the sonar effect if this object is disabled
        if (sonarCoroutine != null)
        {
            StopCoroutine(sonarCoroutine);
        }
    }

    private IEnumerator PlaySonarSound()
    {
        while (true) // Keep looping indefinitely
        {
            // Ensure target and player are still valid
            if (target == null || player == null)
            {
                Debug.LogError("Target or Player is null. Stopping sonar.");
                yield break;
            }

            // Calculate the distance between player and target
            float distance = Vector3.Distance(target.transform.position, player.transform.position);

            // Map the distance to an interval (smaller distance = smaller interval)
            float interval = Mathf.Lerp(minInterval, maxInterval, Mathf.Clamp01(distance / maxDistance));

            // Debug: Log distance and interval for verification
            //Debug.Log($"Distance: {distance}, Interval: {interval}");

            UIManager.Ins.DisplayDistance(distance);

            // Play the sonar sound at full volume
            audioSource.PlayOneShot(sonarAudio, 1f);

            // Find the player
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


            // Wait for the next sonar ping
            yield return new WaitForSeconds(interval);
        }
    }

    public float DistanceToTarget()
    {
        float straighDistanceToTarget = Vector3.Distance(target.transform.position, player.transform.position);
        float gnoe = (target.transform.position - player.transform.position).magnitude;
        return gnoe;
    }
}