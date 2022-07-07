using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortuneScript : MonoBehaviour
{
    public Slider e_slider;
    public Image fill;
    public void SetMaxFortune(int energy)
    {
        e_slider.maxValue = energy;
        e_slider.value = energy;
    }
    public void SetFortune(int energy)
    {
        e_slider.value = energy;
    }
}
