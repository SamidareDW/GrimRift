using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSensor : MonoBehaviour
{
    SlimeEnemy thisSlimeEnemy;
    public Vector3 playerPosition;
    bool _playerDetected;
    public bool playerDetected
    {
        get { return _playerDetected; }
        private set
        {
            if (_playerDetected != value)
            {
                _playerDetected = value;
                ChangedState();
            }
        }
    }
    private void Start() => thisSlimeEnemy = GetComponentInParent<SlimeEnemy>();
    void ChangedState() => thisSlimeEnemy.UppdateInfo();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerDetected = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            playerPosition = other.transform.position;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerDetected = false;
    }
}
