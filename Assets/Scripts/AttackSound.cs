using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakSound : MonoBehaviour
{
    [SerializeField]private GameObject attackSound;
    static double Delay = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) )
        {
            attackSound.SetActive(true);
            Delay = Time.time;
        }
        else if(Time.time >= Delay + 0.3 )
            attackSound.SetActive(false);
    }
}
