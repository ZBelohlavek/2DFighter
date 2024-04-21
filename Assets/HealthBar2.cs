using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarP2 : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealthbar2(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealthbar2(int health)
    {
        slider.value = health;
    }
}
