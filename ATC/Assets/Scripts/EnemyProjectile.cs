using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyProjectile : MonoBehaviour
{


    public Rigidbody2D projectile;

    [SerializeField] float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //projectile.velocity = new Vector2(0,-1) * speed;
        projectile.velocity = Vector2.down * speed;
    }

    //hit detection

    /*void OnCollisionEnter2D(Collision2D collide)
    {
        if(collide.gameObject.tag == "Player")
        {
            collide.gameObject.SetActive (false);
        }
        if(collide.gameObject.name == "BottomWall")
        {
            DestroyObject(this.gameObject);
        }
    
    }*/

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "Player")
        {
        collide.gameObject.SetActive(false);
        
        LoadMainMenu();

        }

        if(collide.gameObject.name == "BottomWall")
        {
            DestroyObject(this.gameObject);
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the actual name of your main menu scene
    }
}