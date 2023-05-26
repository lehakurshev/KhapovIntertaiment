using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class way1 : MonoBehaviour
{
    public GameObject Player;
    public static GameObject Camera0;
    public GameObject Camera;
    public GameObject Out;
    private static DateTime dateTime;
    private static TimeSpan delta;
    // Start is called before the first frame update
    void Start()
    {
        dateTime = DateTime.Now;
        delta = new TimeSpan(0, 0, 0, 1, 50);
        if (Camera != null)
            Camera0 = Camera;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) < 2 && Input.GetKey(KeyCode.E))
            if ((DateTime.Now - dateTime) > delta)
            {
                Player.transform.position = new Vector3(Out.transform.position.x, Out.transform.position.y, Player.transform.position.z);
                Camera0.transform.position = new Vector3(Out.transform.position.x, Out.transform.position.y, Player.transform.position.z);
                dateTime = DateTime.Now;
            }               
    }
}
