using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float currentTime;
    public float startTime;
    public bool finish;
    public bool started = false;

    [SerializeField] public Text text;
    [SerializeField] public Slider slider;

    
    public void SetTimeOut(float value)
    {
        startTime = value;
    }

    public void StartCoundtDown()
    {
        currentTime = startTime;
        slider.value = 1;
        finish = false;
        started = true;
    }

    void Update()
    {
        if(started)
        {
            if(currentTime <= 0)
            {
                finish = true;
                text.text = "OVER";
            }
            else
            {
                currentTime -= Time.deltaTime;
                slider.value = currentTime/startTime;
                text.text = currentTime.ToString("00");
            }
        }
    }
}
