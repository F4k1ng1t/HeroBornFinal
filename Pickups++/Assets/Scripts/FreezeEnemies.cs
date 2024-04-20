using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemies : MonoBehaviour
{
    public PlayerBehavior player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider))
        {
            if (player.flashlightIsOn)
            {
                other.gameObject.GetComponent<EnemyBehavior>().AgentCanMove = false;
                Debug.Log("Enemy Enter Light on");
            }
            else
            {
                other.gameObject.GetComponent<EnemyBehavior>().AgentCanMove = true;
                Debug.Log("Enemy Enter Light off");
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider))
        {
            if (player.flashlightIsOn)
            {
                other.gameObject.GetComponent<EnemyBehavior>().AgentCanMove = false;
            }
            else
            {
                other.gameObject.GetComponent<EnemyBehavior>().AgentCanMove = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider))
        {
            Debug.Log("Enemy Exit");
            other.gameObject.GetComponent<EnemyBehavior>().AgentCanMove = true;
        }
    }
}
