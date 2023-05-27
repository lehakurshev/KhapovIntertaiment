using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider slider;
    private static float a = 1;

    public void Update()
    {
        slider.value = a;
    }

    public void ChangeVolume()
    {
        a = slider.value;
        AudioListener.volume = slider.value;
    }
}
