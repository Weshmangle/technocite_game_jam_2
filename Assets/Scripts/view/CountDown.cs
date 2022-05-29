using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CountDown : MonoBehaviour
{
    public float currentTime;
    public float startTime;
    public bool finish;
    public bool started = false;
    public bool switchColor;
    [SerializeField] public TMPro.TextMeshProUGUI text;
    [SerializeField] public Slider slider;
    [SerializeField] public GameObject sprite;
    
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
        sprite.SetActive(switchColor);
        
        if(started && !GameManager.Instance.game.IsOver())
        {
            if(currentTime <= 0)
            {
                finish = true;
                text.text = "OVER";
            }
            else
            {
                currentTime -= Time.deltaTime;
                slider.value = 1-currentTime/startTime;
                text.text = currentTime.ToString("00");
            }
        }
    }
}