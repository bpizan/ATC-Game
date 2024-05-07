using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public static CheckpointSystem singleton;
    [SerializeField] GameObject player;

    [SerializeField] List<GameObject> checkpoints;
    // Start is called before the first frame update
    void Awake(){
        
        if(singleton != null){
            Debug.LogError("Warning, duplicate checkpoint systems detected");
        }
        singleton = this;

        for(int i = 0; i<checkpoints.Count; i++){
            checkpoints[i].GetComponent<Checkpoint>().SetID(i);
        }
        player.transform.position = checkpoints[PlayerPrefs.GetInt(SaveFlags.currentSaveFile + SaveFlags.checkpointSaveFlag)].transform.position;
    }

    public void ResetColors(){
        foreach(GameObject g in checkpoints){
            g.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

}
