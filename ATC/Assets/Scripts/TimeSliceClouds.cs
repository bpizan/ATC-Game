using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSliceClouds : MonoBehaviour
{
    bool cloudsEnabled = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayerCreature")
        {
            EnableClouds();
        }
    }

    void EnableClouds(){
        if(cloudsEnabled){
            return;
        }
        cloudsEnabled = true;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
