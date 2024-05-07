using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EggCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI eggCounterText;
    public static EggCounter singleton;
    int eggsCollected = 0;

    void Awake(){
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }
    void Start(){

    }

    public void RegisterEgg(int points = 1){
        eggsCollected += points;
        eggCounterText.text = eggsCollected.ToString();
    }


}
