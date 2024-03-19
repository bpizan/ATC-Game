using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{

    public Rigidbody2D projectile;

    [SerializeField] float speed = 10.0f;
  
  
    
    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        projectile.velocity = new Vector2(0,1) * speed;
    }

    //add some hit detection
    void OnCollisionEnter2D(Collision2D collide)
    {
        if(collide.gameObject.name == "TopWall")
        {
            Destroy(this.gameObject);
        }
        if(collide.gameObject.tag == "Destructable"){
            Destroy(collide.gameObject);
            Destroy(this.gameObject);
        }
        
    }


}
