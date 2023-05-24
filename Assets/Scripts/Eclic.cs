using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eclic : MonoBehaviour
{
    public GameObject[] Points;
    public GameObject E;

    // Update is called once per frame
    void Update()
    {
        var a = 0;
        foreach (var pooint in Points)
        {
            if (Vector2.Distance(transform.position, pooint.transform.position) < 2)
            {
                a++;
            }
        }
        if (a > 0){
            E.SetActive(true);

        }
        else
        {
            E.SetActive(false);
        }
    }
}
