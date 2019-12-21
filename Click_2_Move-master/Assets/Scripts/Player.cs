using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    

    public GameObject moveCommand;
    public GameObject AttackCommand;
    public GameObject enemy;
    public Vector3 target;
    public Vector3 relavtivePos;
    public event Action attack;
    public event Action walk;
    public bool attacking;

    public float disFromDestination;

    public  bool isSelected;
    public bool isLeader;

    public enum PlayerStates { Moving, Attacking }
    public static PlayerStates currentState;
    private void Update()
    {
        if (isSelected)
        {
            var agent = GetComponent<NavMeshAgent>();

            disFromDestination = Vector3.Distance(target, transform.position);
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider.tag == "Ground")
                    {
                        currentState = PlayerStates.Moving;
                        if (isLeader)
                        {
                            target = hit.point;
                            Instantiate(moveCommand, target, Quaternion.identity);
                        }
                        else
                        {
                            target = hit.point - relavtivePos;
                        }
                        agent.SetDestination(target);
                        walk?.Invoke();
                        Stop();
                    }
                    if (hit.collider.tag == "Enemy")
                    {
                        currentState = PlayerStates.Attacking;

                        enemy = hit.collider.gameObject;
                        target = hit.point;
                        agent.SetDestination(target);
                        Instantiate(AttackCommand, target, Quaternion.identity);
                    }
                }
            }

            if (currentState == PlayerStates.Attacking)
            {
                if (enemy == null)
                {
                    walk?.Invoke();
                }
                else
                {
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);
                    if (dist <= 2f)
                    {
                        agent.SetDestination(transform.position);
                        if (!attacking)
                        {
                            attacking = true;
                            StartCoroutine(AutoAttack());
                        }
                    }
                    else if (dist > 2f)
                    {
                        Stop();
                    }
                    Enemy deEn = enemy.GetComponent<Enemy>();
                    if (deEn.health <= 0)
                    {
                        enemy = null;

                        Stop();
                    }
                    
                }
            }
        }
        
        
    }

    private IEnumerator AutoAttack()
    {
        attack?.Invoke();
        yield return new WaitForSeconds(0.75f);
        enemy.GetComponent<Enemy>().Damage();
        Debug.Log("dmg");
        StartCoroutine(AutoAttack());
    }

    public void StopMovements()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(transform.position);
    }
    public void SelectOnOff()
    {
        isSelected = !isSelected;
    }

    private void Stop()
    {
        StopAllCoroutines();
        attacking = false;
    }
}
