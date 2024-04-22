using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject Text;
    public GameBehavior gameManager;
    public Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        //_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Text.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Text.SetActive(true);
            if (Input.GetKey(KeyCode.E) && gameManager.Locks == 0)
            {
                _anim.Play("ButtonPress");
                Debug.Log("Button pressed");
                Text.SetActive(false);
                gameManager.ButtonPressed = true;
            }
            else if (Input.GetKey(KeyCode.E) && gameManager.Locks >= 0)
            {
                _anim.Play("ButtonPress");
                gameManager.LabelText = "Hm. nothing happened.";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Text.SetActive(false);
    }
}

