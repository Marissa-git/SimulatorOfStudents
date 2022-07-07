using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnowledgeRepBarScript : MonoBehaviour
{
    public Slider k_slider;
    public Image fill;
    public void SetMaxRepKnow(int val)
    {
        k_slider.maxValue = val;
        k_slider.value = val;
    }
    public void SetRepKnow(int val)
    {
        k_slider.value = val;
    }
}
