using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameBehavior gameBehavior;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameBehavior.ButtonPressed)
            {
                gameBehavior.showWinScreen = true;
            }
            else
            {
                gameBehavior.LabelText = "You're not supposed to be here";
                gameBehavior.Jumpscare();
            }
        }
        
        
    }
}
