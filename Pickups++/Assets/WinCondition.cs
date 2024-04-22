using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WinCondition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameBehavior gameBehavior;
    private void OnTriggerEnter(Collider other)
    {
        gameBehavior.showWinScreen = true;
    }
}
