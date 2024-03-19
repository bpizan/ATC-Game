using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*[Header("Stats")]
    [SerializeField] int health = 3;
    [SerializeField]  float speed = 0.0f;

    [SerializeField]  int jumpForce = 10;   
    public enum CreatureMovementType{tf, physics};
    [SerializeField] CreatureMovementType movementType = CreatureMovementType.tf;

    [Header("Physics")]
    [SerializeField] LayerMask groundMask;

    [SerializeField] float jumpOffset = -.5f;
    [SerializeField] float jumpRadius = .25f;

    [Header("Flavor")]
    [SerializeField]  string creatureName = "Circle";
    [SerializeField] private GameObject body;

    [Header("Tracked Data")]
    [SerializeField]  Vector3 homePosition = Vector3.zero;

    [SerializeField] GameObject box;

    Rigidbody2D rb;*/

    public class Creature : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int health = 3;
    
    [SerializeField] int stamina = 3;
    [SerializeField] float speed = 0f;
    [SerializeField] float jumpForce = 10;

    public enum CreatureMovementType { tf , physics };
    [SerializeField] CreatureMovementType movementType = CreatureMovementType.tf;

    [Header("Physics")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpOffset = -.5f;
    [SerializeField] float jumpRadius = .25f;

    [Header("Flavor")]
    [SerializeField] string creatureName = "Circle";
    [SerializeField] private GameObject body;
    
    //[SerializeField] private List<AnimationStateChanger> animationStateChangers;

    [Header("Tracked Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;
    [SerializeField] CreatureSO creatureSO;

    Rigidbody2D rb;



    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(health);


    }

/*
        GetComponent<SpriteRenderer>().color = Color.blue;
        Creature creature = GetComponent<Creature>();
*/
     //   GetComponent<Transform>().position += new Vector3(10,0,0);
        //ALSO WORKS ---> transform.position += new Vector3(10,0,0);//
    
    

    // Update is called once per frame
    void Update()
    {
    //    MoveCreature(new Vector3(-1,-1,0));
    if(creatureSO != null){
        creatureSO.health = health;
        creatureSO.stamina = stamina;
    }
    }
    void FixedUpdate(){

    }


    public void MoveCreature(Vector3 direction)
    {
        
        if(movementType == CreatureMovementType.tf){
            MoveCreatureTransform(direction);
        }
        else if(movementType == CreatureMovementType.physics){
            MoveCreatureRb(direction);
        }

    }

    public void MoveCreatureRb(Vector3 direction)
    {
        Vector3 currentVelocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = (currentVelocity) + (direction * speed);
        if(rb.velocity.x < 0){
            body.transform.localScale = new Vector3(-1,1,1);
        }else if(rb.velocity.x > 0){
            body.transform.localScale = new Vector3(1,1,1);
        }
        //rb.AddForce(direction * speed);
        //rb.MovePosition(transform.position + (direction * speed * Time.deltaTime))
    }

    public void Jump()
    {
        if(Physics2D.OverlapCircleAll(transform.position + new Vector3(0,jumpOffset,0),jumpRadius,groundMask).Length > 0){
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    public void MoveCreatureTransform(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
 
    }

    public void PickupCoin(){
        CoinCounter.singleton.RegisterCoin();
        GetComponent<AudioSource>().Play();
    }
}
