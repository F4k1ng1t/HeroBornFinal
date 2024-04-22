using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] int time = 30;


    IEnumerator Countdown()
    {
        timer.text = $"{time}s";
        yield return new WaitForSeconds(1);
        time--;
    }
    public void StartTimer()
    {
        timer.enabled = true;
        while(time > 0)
            StartCoroutine(Countdown());
    }
}
