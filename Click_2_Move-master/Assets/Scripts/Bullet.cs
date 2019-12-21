using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 15f;
    private Enemy host;
    private void Start()
    {
        host = GetComponent<Enemy>();
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Enemy.toTarget* force, ForceMode.Impulse);
    }


    
       
        
        
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
