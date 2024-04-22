using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
    
{
    public GameBehavior gameManager;
    public void Showloss()
    {
        gameManager.Showloss();
    }
    void OnEnable()
    {
        AudioSource jumpscare = GetComponent<AudioSource>();
        jumpscare.Play();
    }
}
