using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    int checkpointID = -1;

    public void SetID(int id){
        checkpointID = id;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "PlayerCreature"){
            PlayerPrefs.SetInt(SaveFlags.currentSaveFile + SaveFlags.checkpointSaveFlag,checkpointID);
            CheckpointSystem.singleton.ResetColors();
            //GetComponent<SpriteRenderer>().color = new Color(1.0f,0.0f,0.0f);
            
        }
    }
}
