using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float view;
    public float speed;
    public Animator enemyanimator;
    public GameObject player;
    public GameObject enemy;
    public GameObject Player;

    private Transform target;
    
	void Start ()
    {
        target = player.GetComponent<Transform>();
        enemyanimator = enemy.GetComponent<Animator>();
    }

    void Update()
    {
        Chasing();
    }

    void OnTriggerEnter(Collider other) 
    {

     if (other.gameObject == Player)
     { 
         Debug.Log("koniec");
         Application.Quit();
     }

    }
    void Chasing()
    {
        if (Vector3.Distance(transform.position, target.position) < view)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Vector3 targetPosition = new Vector3(target.position.x, target.transform.position.y, target.position.z);
            this.transform.LookAt(targetPosition);
            this.transform.Rotate( 0, 90, 0 ) ;
            enemyanimator.SetBool("isChasing", true);
        }
        else
        {
            enemyanimator.SetBool("isChasing", false);
        }
    }
}
