using System.Collections;
using UnityEngine;

public class FinalPlatform : MonoBehaviour
{
    [SerializeField] Transform destination; // Final destination of the platform
    [SerializeField] float moveTime = 4f;   // Time to reach the final destination
    private bool hasStarted = false;        // To ensure the movement starts only once

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the PlayerCreature and if the platform hasn't started moving yet
        if (other.gameObject.CompareTag("Player") && !hasStarted)
        {
            hasStarted = true;
            StartCoroutine(MoveToFinalDestination());
        }
    }

    IEnumerator MoveToFinalDestination()
    {
        float timer = 0;
        Vector3 startPosition = transform.position;

        while (timer < moveTime)
        {
            yield return null;
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, destination.position, timer / moveTime);
        }
        
        // Ensure the platform is exactly at the final destination
        transform.position = destination.position;
    }
}
