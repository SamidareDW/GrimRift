using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    public GameObject DeadCanv;
    SlimeSensor sensor;
    Vector3 lastKnownPlayerPosition;
    bool _isPlayerInRange;
    bool isPlayerInRange
    {
        get { return _isPlayerInRange; }
        set
        {
            if(_isPlayerInRange != value)
            {
                _isPlayerInRange = value;
                if (value)
                    StartCoroutine(AttackPlayer());
            }
        }
    }


    new Rigidbody rigidbody;

    public float attackDealay;
    public float jumpForce;
    public float detectionRange;

    private void Start()
    {
        sensor = GetComponentInChildren<SlimeSensor>();
        rigidbody = GetComponent<Rigidbody>();
        sensor.GetComponent<SphereCollider>().radius = detectionRange;
    }

    void UppdatePlayerPosition() => lastKnownPlayerPosition = sensor.playerPosition;
    void UppdateIfPlayerIsInRange() => isPlayerInRange = sensor.playerDetected;
    public void UppdateInfo()
    {
        UppdatePlayerPosition();
        UppdateIfPlayerIsInRange();
    }
    void LookAtPlayer()
    {
        UppdatePlayerPosition();
        transform.LookAt(lastKnownPlayerPosition);
    }

    void JumpForward()
    {
        rigidbody.AddForce((transform.forward + Vector3.up) * jumpForce, ForceMode.Impulse);
    }

    IEnumerator AttackPlayer()
    {
        while (isPlayerInRange)
        {
            LookAtPlayer();
            JumpForward();
            yield return new WaitForSeconds(attackDealay);
        }
    }
}
