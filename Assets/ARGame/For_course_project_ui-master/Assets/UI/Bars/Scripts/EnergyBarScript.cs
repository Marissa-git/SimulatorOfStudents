using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarScript : MonoBehaviour
{
    public Slider e_slider;
    public Gradient gradient;
    public Image fill;
    public Image e_sprite;
    public void SetMaxEnergy(int energy)
    {
        e_slider.maxValue = energy;
        e_slider.value = energy;
        fill.color = gradient.Evaluate(e_slider.normalizedValue);
        e_sprite.color = gradient.Evaluate(e_slider.normalizedValue);
    }
    public void SetEnergy(int energy)
    {
        e_slider.value = energy;
        fill.color = gradient.Evaluate(e_slider.normalizedValue);
        e_sprite.color = gradient.Evaluate(e_slider.normalizedValue);
    }
}
