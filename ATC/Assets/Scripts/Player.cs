using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] float speed = 0.0f;
    Rigidbody2D rb;
    // Start is called before the first frame update

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
    }

    public void PickupCoin(){
        CoinCounter.singleton.RegisterCoin();
        GetComponent<AudioSource>().Play();
    }
}
