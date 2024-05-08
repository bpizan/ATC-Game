using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GoldenEggPickerUpper : MonoBehaviour
{
    public UnityEvent onGoldenEggPickup;

    void Start()
    {
        onGoldenEggPickup.AddListener(WinGame);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<GoldenEgg>() != null)
        {
            onGoldenEggPickup.Invoke();
        }
    }

    void WinGame()
    {
        Debug.Log("Golden Egg picked up! Loading win scene.");
        SceneManager.LoadScene("Win"); // Ensure this scene is in your build settings
    }
}
