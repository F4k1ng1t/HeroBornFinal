using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitWhat : MonoBehaviour
{
    public GameBehavior gameManager;
    private void OnTriggerEnter(Collider other)
    {
        gameManager.labelText = "What? There's another gate! Maybe pressing that button will open it.";
        Destroy(this.gameObject);
    }
}
