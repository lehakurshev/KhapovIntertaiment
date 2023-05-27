using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attak : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject attakDo0und;
    static double time = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) )
        {
            attakDo0und.SetActive(true);
            time = Time.time;
        }
        else if(Time.time >= time + 0.3 )
            attakDo0und.SetActive(false);
    }
}
