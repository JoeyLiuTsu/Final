using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private List<GameObject> players;

    public GameObject explosion;
    private GameObject target;
    private bool isLocked;
    public static Vector3 toTarget;
    public GameObject bullet;
    public float health;

    private void Awake()
    {
        players = new List<GameObject>();
        health = 100;
    }
    private void Update()
    {
        if (players.Count != 0)
        {
            target = players[0];
        }
        
        if (target)
        {
            
            toTarget = target.transform.position - transform.position;
            if (!isLocked)
            {
                isLocked = true;
                StartCoroutine(Fire());
            }
        }
        else
        {
            Debug.Log("Lol");
            isLocked = false;
            StopAllCoroutines();
        }
        
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject UPlayer = other.gameObject;
            if (UPlayer != null)
            {
                if (!players.Contains(UPlayer))
                {
                    
                    players.Add(UPlayer);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject UPlayer = other.gameObject;
            if (UPlayer != null)
            {
                if (players.Contains(UPlayer))
                {
                    
                    players.Remove(UPlayer);
                }
            }
        }
        
    }
    public void Damage()
    {
        health -= 25;
    }
    public void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 up = transform.position;
        up.y += 1;
        Instantiate(bullet, up, Quaternion.identity);
        StartCoroutine(Fire());
    }
}
