using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Q1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            Q1.SetActive(false);
    }
}
