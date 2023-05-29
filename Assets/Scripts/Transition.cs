using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private CanvasGroup canv;

    private void Update()
    {
        if(canv.alpha < 1)
        {
            canv.alpha += Time.deltaTime;
        }
    }
}
