using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] CheckpointSystem checkpointSystem; // Reference to the CheckpointSystem

    void Start()
    {
        // Ensure there is a reference to the CheckpointSystem
        if (checkpointSystem == null)
        {
            checkpointSystem = FindObjectOfType<CheckpointSystem>();
            if (checkpointSystem == null)
            {
                Debug.LogError("CheckpointSystem not found in the scene.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerCreature")
        {
            // Get the last checkpoint index from PlayerPrefs
            int lastCheckpointIndex = PlayerPrefs.GetInt(SaveFlags.currentSaveFile + SaveFlags.checkpointSaveFlag, 0); // Default to 0 if not found
            if (checkpointSystem != null && checkpointSystem.checkpoints.Count > lastCheckpointIndex)
            {
                // Teleport the player to the last saved checkpoint position
                other.transform.position = checkpointSystem.checkpoints[lastCheckpointIndex].transform.position;
            }
            else
            {
                Debug.LogError("Invalid checkpoint index or CheckpointSystem not properly initialized.");
            }
        }
    }
}
