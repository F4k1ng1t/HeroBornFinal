using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public int time = 30;


    // Start is called before the first frame update
    void StartTimer()
    {
        timer.enabled = true;
        timer.text = $"{time}s";
        Invoke("PassTime", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PassTime()
    {
        if (time > 0)
        {
            time--;
            timer.text = $"{time}s";
            Invoke("PassTime", 1f);
        }
        
        
    }
}
