using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;

    //public float damage;
    public float longDistance;
    public float shortDistance;
    public float speed;
    public float force;

    //private static DateTime dateTime;
    //private static TimeSpan delta;

    //public GameObject bullet;
    //public Transform shotPoint;

    void Start()
    {
        //dateTime = DateTime.Now;
        //delta = new TimeSpan(0, 0, 0, 3, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > longDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
        if (Vector2.Distance(transform.position, target.position) < shortDistance)
        {
            Debug.Log("ok");
            var directionImpulse = (target.position - transform.position).normalized;
            Debug.Log($"{directionImpulse}");
            rb.AddForce(directionImpulse * 200, ForceMode2D.Impulse);
        }

    }
}
