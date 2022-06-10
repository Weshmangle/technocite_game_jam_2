using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float maxTime;
    public float currentTime;

    public bool finish
    {
        get {return currentTime >= maxTime;}
    }

    public void Start(float maxTime)
    {
        this.maxTime = maxTime;
        currentTime = 0;
    }

    void Update()
    {
        if(!finish)
        {
            currentTime += Time.deltaTime;
        }
    }
}