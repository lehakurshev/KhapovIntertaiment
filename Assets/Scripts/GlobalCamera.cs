using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera1;
    public GameObject Q;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Q)))
        {
            camera1.SetActive(true);
            Q.SetActive(false);
            Time.timeScale = 0f;
        }

        else
        {
            camera1.SetActive(false);
            Time.timeScale = 1f;
        }
            
    }
}
