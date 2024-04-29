using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    [SerializeField] GameObject timerObject;
    [SerializeField] TextMeshProUGUI timer;
    //[SerializeField] int time = 30;
    float time = 30f;
    bool timerStart = false;



    public void StartTimer()
    {
        timerObject.SetActive(true);
        timerStart = true;
    }  
    private void Update()
    {
        if (timerStart && Mathf.Ceil(time) > 0)
        {
            time -= 1 * Time.deltaTime;
            timer.text = $"{Mathf.Ceil(time)}s";
        }
    }
}
