using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnim : MonoBehaviour
{
    public Animator anim;
    private Player player;
    private Vector3 previousPosition;
    public float curSpeed;

    private void Awake()
    {
        player = GetComponent<Player>();
        player.attack += Player_Attack;
        player.walk += Player_Cancel;

    }
    private void Player_Attack()
    {
        anim.SetTrigger("Attack");
    }
    
    private void Player_Cancel()
    {
        anim.SetTrigger("Cancel_1");
    }
    void Update()
    {
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
        var agent = GetComponent<NavMeshAgent>();
        anim.SetFloat("Speed", curSpeed);
    }
}
