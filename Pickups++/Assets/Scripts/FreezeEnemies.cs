using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyBehavior>().agentCanMove = false;
            other.gameObject.GetComponent<EnemyBehavior>().agent.destination = other.gameObject.transform.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyBehavior>().agentCanMove = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyBehavior>().agentCanMove = true;
            other.gameObject.GetComponent<EnemyBehavior>().agent.destination = GameObject.Find("Player").transform.position;
        }
    }
}
