using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealthbar(int health)
    {
        slider.maxValue = health;
        slider.value = health; 
    }

    public void SetHealthbar(int health)
    {
        slider.value = health;
    }
}
