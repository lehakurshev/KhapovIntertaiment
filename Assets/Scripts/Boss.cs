using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;
    public Animator animator;

    //public float damage;
    public float longDistance;
    public float shortDistance;
    public float speed;

    public bool isFacingRight;

    private DateTime dateTime;
    private static TimeSpan deltaState;
    private static TimeSpan deltaFire;

    private bool isFire;

    public Bullet bullet;
    public Transform shotPoint;

    private DateTime dateTimePos;
    private static TimeSpan deltaTimePos;
    private System.Random random1;
    private System.Random random2;

    public GameObject stone1;
    public GameObject stone2;
    public GameObject stone3;
    public GameObject stone4;

    void Start()
    {
        dateTime = DateTime.Now;
        dateTimePos = DateTime.Now;
        deltaState = new TimeSpan(0, 0, 0, 1, 0);
        deltaFire = new TimeSpan(0, 0, 0, 1, 10);
        deltaTimePos = new TimeSpan(0, 0, 0, 6, 0);
        isFacingRight = true;
        random1 = new System.Random();
        random2 = new System.Random();
        random2 = new System.Random();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stone1 == null && stone2 == null && stone3 == null && stone4 == null) 
        {
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, target.position) > longDistance)
        {
            var vector = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            vector.z = -8;
            transform.position = vector;
        }
        else if (Vector3.Distance(transform.position, target.position) < shortDistance)
        {
            var directionImpulse = (target.position - transform.position).normalized;
            rb.AddForce(directionImpulse * 20000, ForceMode2D.Force);
        }
        else
        {
            if (DateTime.Now - dateTimePos > deltaTimePos)
            {
                Vector3 vector = target.position;
                var dx = (longDistance / 1.41) * (random1.Next(0,2) ==0 ? -1 : 1);
                var dy = (longDistance / 1.41) * (random2.Next(0, 2) == 0 ? -1 : 1);
                vector.x = vector.x + (float)dx;
                vector.y = vector.y + (float)dy;
                vector.z = -8;
                transform.position = vector;
                dateTimePos = DateTime.Now;
            }      
        }
        Flip();

        if (!isFire) 
        {
            if (DateTime.Now - dateTime > deltaState)
            {
                animator.SetBool("Fire", true);
                isFire = true;
                dateTime = DateTime.Now;                
            }
        }
        else
        {
            if (DateTime.Now - dateTime > deltaFire)
            {
                animator.SetBool("Fire", false);
                isFire = false;
                dateTime = DateTime.Now;
                bullet.direction = (target.position - transform.position).normalized;
                var currBullet = Instantiate(bullet, shotPoint.position, transform.rotation);
            }
        }
        
    }

    private void Flip()
    {
        if (isFacingRight && (target.position.x - transform.position.x) < 0f || !isFacingRight && (target.position.x - transform.position.x) > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
