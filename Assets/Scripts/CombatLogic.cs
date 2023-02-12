using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class CombatLogic : MonoBehaviour
{
    public Transform CurrentEnemy;
    [HideInInspector] public bool attackMode = false;
    [HideInInspector] public NavMeshAgent Agent;
    private int CurrentEnemyHealth;
    private int CurrentEnemyMaxHealth;
    public float detectionRange = 10;
    public float chasingRange = 20;
    [HideInInspector]public Animator Animator;
    [HideInInspector] public bool 
        isDead = false, isRunning = false, isAttacking = false;


    void Start()
    {
        
        
    }


    void Update()
    {
        DetectPlayer();
        Fighting();
    }

    public void DetectPlayer()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        if (!attackMode)
        {
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Player")
                {
                    //Debug.Log("W zasięgu");
                    CurrentEnemy = hitCollider.GetComponent<Transform>();
                    attackMode = true;
                }

            }
        }
    }
    public void Death()
    {
        CurrentEnemy.GetComponent<MyPlayerController>().isDead = true;
        SoundManager.current.PlaySound(SoundManager.Sound.PlayerDeath);
    }
    
    public void AttackSound()
        {
            SoundManager.current.PlaySound(SoundManager.Sound.MonsterCharge);
        }
    
    public void MonsterStepSound()
    {
        SoundManager.current.PlaySound(SoundManager.Sound.MonsterStep);
    }
    
    public void Fighting()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        
        if (attackMode)
        {
            
            transform.LookAt(CurrentEnemy.transform);

            if ((Vector3.Distance(transform.position, CurrentEnemy.transform.position) > 1.5) &&
                (Vector3.Distance(transform.position, CurrentEnemy.transform.position) < chasingRange))
            {
                isRunning = true;
                isAttacking = false;
                Agent.isStopped = false;
                Agent.destination = CurrentEnemy.position;
            }
            if ((Vector3.Distance(transform.position, CurrentEnemy.transform.position) <= 1.5))
            {
                isRunning = false;
                isAttacking = true;
            }

            if (CurrentEnemy.GetComponent<MyPlayerController>().isDead == true)
            {
                isAttacking = false;
                attackMode = false;
            }

            if ((Vector3.Distance(transform.position, CurrentEnemy.transform.position) >= chasingRange))
            {
                CurrentEnemy = null;
                isRunning = false;
                isAttacking = false;
                attackMode = false;
                Agent.isStopped = true;
            }
        }

        Animator.SetBool("isRunning", isRunning);
        Animator.SetBool("isAttacking", isAttacking);
    }
    
    
    /*public void Death()
    {
        Animator = GetComponent<Animator>();

        CurrentEnemy = null;
        isRunning = false;
        isAttacking = false;
        attackMode = false;
        Agent.isStopped = true;
        isDead = true;
        
        MonsterDeath();

        Animator.SetBool("isDead", isDead);
        GetComponent<NavMeshAgent>().enabled = !GetComponent<NavMeshAgent>().enabled;
    }*/
}


