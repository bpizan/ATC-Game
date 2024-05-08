using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EggPickerUpper : MonoBehaviour
{
    public UnityEvent onEggPickup;

    //this is how we can pass along data to functions through our events
    // [System.Serializable]
    // public class MyEvent : UnityEvent<int> {}
    // public MyEvent myPickupEvent;

    void Start(){
        onEggPickup.AddListener(PrintPickup);

    }

    void PrintPickup(){
        Debug.Log("Picked up egg!");
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Egg>() != null){
            onEggPickup.Invoke();
            //myPickupEvent.Invoke(42); //this is how we can pass along data to functions, select the dynamic option if doing so through inspector
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
    }
}
