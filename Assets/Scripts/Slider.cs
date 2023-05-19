using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider slider;

    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
    }
}
