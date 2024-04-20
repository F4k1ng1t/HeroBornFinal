using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    public PlayerBehavior Player;
    public GameBehavior gameManager;
    public GameObject Lock1;
    public GameObject Lock2;
    public GameObject Lock3;
    public GameObject LeftDoor;
    public GameObject Rightdoor;
    public Animator left_anim;
    public Animator right_anim;


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
                    if (left_anim != null)
                        left_anim.Play("GateOpen2");
                    if (right_anim != null)
                        right_anim.Play("GateOpen1");
                }

            }
        }
    }
}
