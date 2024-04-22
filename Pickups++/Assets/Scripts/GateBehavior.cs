using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    public PlayerBehavior Player;
    public GameBehavior gameManager;
    public GameObject Lock1;
    public GameObject Lock2;
    public GameObject Lock3;
    public GameObject LeftDoor;
    public GameObject RightDoor;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

   void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && Player.hasKey)
        {
            if (Input.GetKeyDown(KeyCode.E) && Player.keyIsOut)
            {
                gameManager.currentKeys -= 1;
                if (gameManager.Locks == 3)
                {
                    Lock3.SetActive(false);
                    gameManager.Locks -= 1;
                }
                else if (gameManager.Locks == 2)
                {
                    Lock2.SetActive(false);
                    gameManager.Locks -= 1;
                }
                else if (gameManager.Locks == 1)
                {
                    Lock1.SetActive(false);
                    gameManager.Locks -= 1;
                    //LeftDoor.SetActive(false);
                    //RightDoor.SetActive(false);
                    Animator _anim = GetComponent<Animator>();
                    _anim.Play("GateOpen1");

                }

            }
        }
    }
}
