using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float maxTime = 0;
    public float currentTime = -1;
    public bool started = false;

    public bool finish
    {
        get {return currentTime >= maxTime;}
    }

    public bool running
    {
        get {return finish && started;}
    }

    public float normalizeValue
    {
        get {return currentTime / maxTime;}
    }

    public void StartTimer(float maxTime)
    {
        this.maxTime = maxTime;
        currentTime = 0;
        started = true;
    }

    void Update()
    {
        if(!finish && started)
        {
            currentTime += Time.deltaTime;
        }
    }
}