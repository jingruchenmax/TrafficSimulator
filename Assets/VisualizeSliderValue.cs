using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeSliderValue : MonoBehaviour
{
    public Slider slider;
    public void UpdatSliderValue()
    {
        GetComponent<Text>().text = slider.value.ToString();
    }
}
