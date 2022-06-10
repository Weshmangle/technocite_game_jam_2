using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Gauge : MonoBehaviour
{
    public bool switchColor;
    [SerializeField] public TMPro.TextMeshProUGUI text;
    [SerializeField] public Slider slider;
    [SerializeField] public GameObject sprite;

    public float value
    {
        get {return slider.value;}
    }

    public void Reset()
    {
        slider.value = 1;
    }

    public void Increment(float value)
    {
        slider.value = Mathf.Clamp(1 - (value + slider.value), 0, 1);
    }

    public void SetValue(float value)
    {
        slider.value = Mathf.Clamp(1 - value, 0, 1);
    }

    void Update()
    {
        sprite.SetActive(switchColor);
    }
}