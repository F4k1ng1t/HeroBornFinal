using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform patrolRoute;

    public List<Transform> locations;

    public int locationIndex = 0;

    public NavMeshAgent agent;

    public Transform player;

    private int _lives = 3;

    public HideEnemy hide;

    private bool agentCanMove = true;
    public bool AgentCanMove
    {
        get { return agentCanMove; }

        set
        {
            agentCanMove = value;

            if (agentCanMove)
            {
                ResetPatrolRoute();
            }
                
            else
                agent.destination = this.transform.position;

            
        }
    }
    public int Enemylives
    {
        get { return _lives; }

        set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }
        }
    }
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        if(GetComponent<HideEnemy>() != null)
            hide = GetComponent<HideEnemy>();

        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }
    void ResetPatrolRoute()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    void Update()
    {
        if(agent.remainingDistance < 0.2f && !agent.pathPending && agentCanMove)
        {
            MoveToNextPatrolLocation();
        }    
    }
    private void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
            return;

        agent.destination = locations[locationIndex].position;


        locationIndex = (locationIndex + 1) % locations.Count;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Enemylives -= 1;
            Debug.Log("Got em!");
        } 
            
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Detected - attack!");
            //hide.EnemyShow();
            if (agentCanMove)
            {
                agent.destination = player.position;
            }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (agentCanMove)
            {
                agent.destination = player.position;
            }
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
            ResetPatrolRoute();
            //hide.EnemyHide();
        }
        
    }
}
