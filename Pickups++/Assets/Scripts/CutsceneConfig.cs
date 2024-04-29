using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneConfig : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] Transform player;
    [SerializeField] GameObject miniMap;
    [SerializeField] GameBehavior gameManager;
    [SerializeField] GameObject interactText;

    int dialogueLine = 0;
    public void SwitchCams()
    {
        miniMap.SetActive(true);
        mainCamera.SetActive(true);
        interactText.SetActive(true);
        this.gameObject.SetActive(false);
        
    }
    public void NextDialogue()
    {
        switch (dialogueLine)
        {
            case 0:
                interactText.SetActive(false);
                gameManager.LabelText = "Ugh...";
                dialogueLine++;
                break;
            case 1:
                gameManager.LabelText = "Where am I?";
                dialogueLine++;
                break;
            case 2:
                gameManager.LabelText = "My head hurts...";
                dialogueLine++;
                break;

            case 3:
                
                dialogueLine++;
                break;
            case 4:
                gameManager.LabelText = "Woah... It's dark. What is this?";
                dialogueLine++;
                break;
            case 5:
                
                dialogueLine++;
                break;
            case 6:
                gameManager.LabelText = "Is that a gate? 3 locks...";
                dialogueLine++;
                break;
            case 7:
                gameManager.LabelText = "Hm...";
                dialogueLine++;
                break;
            case 8:
                gameManager.LabelText = "Nice! A flashlight!";
                dialogueLine++;
                break;
            case 9:
                gameManager.LabelText = "Gotta find 3 keys...";
                break;

            default:
                gameManager.LabelText = "somethings wrong";
                break;
        }

    }
}
