using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenEgg : MonoBehaviour
{
    // This script can be expanded with additional golden egg-specific properties or methods.

    void OnTriggerEnter2D(Collider2D other)
    {
        // You can check for a specific component if you want only certain objects to interact with the golden egg.
        // For example, check if the collider has a GoldenEggPickerUpper component.
        GoldenEggPickerUpper pickerUpper = other.GetComponent<GoldenEggPickerUpper>();
        if (pickerUpper != null)
        {
            // Invoke any specific interactions here if necessary
            Destroy(gameObject);  // Destroy the golden egg after it is "picked up"
        }
    }
}
