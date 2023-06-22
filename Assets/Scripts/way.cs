using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Way : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public static GameObject Camera;
    [SerializeField] private GameObject currCamera;
    [SerializeField] private GameObject exit;
    private static DateTime dateTime;
    private static TimeSpan delta;

    // Start is called before the first frame update
    void Start()
    {
        dateTime = DateTime.Now;
        delta = new TimeSpan(0, 0, 0, 1, 50);
        if (Camera != null)
            Camera = currCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < 2 && Input.GetKey(KeyCode.E))
            if ((DateTime.Now - dateTime) > delta)
            {
                player.transform.position = new Vector3(exit.transform.position.x, exit.transform.position.y, player.transform.position.z);
                Camera.transform.position = new Vector3(exit.transform.position.x, exit.transform.position.y, player.transform.position.z);
                dateTime = DateTime.Now;
            }
    }
}

