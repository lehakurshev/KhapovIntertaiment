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

    private static DateTime dateTime;
    private static TimeSpan deltaState;
    private static TimeSpan deltaFire;

    private bool isFire;

    public Bullet bullet;
    public Transform shotPoint;

    void Start()
    {
        dateTime = DateTime.Now;
        deltaState = new TimeSpan(0, 0, 0, 1, 0);
        deltaFire = new TimeSpan(0, 0, 0, 1, 10);
        isFacingRight = true; 
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
            var directionImpulse = (target.position - transform.position).normalized;
            rb.AddForce(directionImpulse * 20000, ForceMode2D.Force);
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
            Debug.Log("a");
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
