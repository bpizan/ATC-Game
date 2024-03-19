using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform projectileSpawn;

    public GameObject projectile;
    [SerializeField] float nextFire = 1.0f;

    [SerializeField] float currentTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        projectileSpawn = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        currentTime += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && currentTime > nextFire)
        {
            nextFire += currentTime; 

            Instantiate (projectile, projectileSpawn.position, Quaternion.identity);

            nextFire -= currentTime;
            currentTime = 0.0f;

        }        
    }

}
