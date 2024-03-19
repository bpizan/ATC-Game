using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Player>() != null){
           other.GetComponent<Player>().PickupCoin();
            Destroy(this.gameObject);
        }
    }


}