using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.Rendering;
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

    private System.Random random1;
    private System.Random random2;
    private System.Random random3;

    public GameObject[] stones;

    public int directionRotate;
    public bool isRotate;
    public bool isMove;
    private float angleRotate;
    private double radius;
    public float speedRotate;
    public float startAngle;
    private DateTime dateTimeRot;
    private TimeSpan deltaTimeRot;

    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public BossChildren children;
    public GameObject children0;
    private int counterorChildren;
    private int BrokenStones;
    private bool isHard;

    private Vector3 pointForMove1;
    private Vector3 pointForMove2;
    private Vector3 currDirection;
    private int counterForMove;
    public int distance;
    public float speedMove;

    void Start()
    {
        dateTime = DateTime.Now;
        dateTimeRot = DateTime.Now;
        deltaState = new TimeSpan(0, 0, 0, 1, 0);
        deltaFire = new TimeSpan(0, 0, 0, 1, 10);
        deltaTimeRot = new TimeSpan(0, 0, 0, 4, 0);
        isFacingRight = true;
        random1 = new System.Random();
        random2 = new System.Random();
        random3 = new System.Random();
        counterorChildren = 0;
        BrokenStones = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        children0.transform.position=new Vector3(int.MaxValue / 2, int.MaxValue / 2, int.MinValue / 2);
        BrokenStones = 0;
        foreach (var stone in stones)
        {
            if (stone == null)
                BrokenStones += 1;
        }
         

        if (BrokenStones==4) 
        {
            Destroy(gameObject);
        }
        BrokenStones = 0;
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
            if (DateTime.Now - dateTimeRot > deltaTimeRot)
            {
                var dx = transform.position.x - target.position.x;
                var dy = transform.position.y - target.position.y;
                if (!isRotate && !isMove && (Math.Max(Math.Abs(dx), Math.Abs(dy)) < 3f || random3.Next(0, 2) == 1))
                {
                    radius = Math.Sqrt((dx * dx) + (dy * dy));
                    radius = Math.Sqrt((dx * dx) + (dy * dy));
                    startAngle = MathF.Atan2(dy, dx);
                    angleRotate = (float)(random1.NextDouble() * 3f * 3.14f) + 1.62f;
                    isRotate = true;
                    directionRotate = random2.Next(0, 2) == 0 ? 1 : -1;
                }
                else if (!isMove && !isRotate)
                {
                    if (random2.NextDouble() > 0.5 || Math.Abs(dy) < 3f)
                    {
                        pointForMove1 = new Vector3(dx, (float)Math.Sqrt((longDistance * longDistance) - (dx * dx) - 1), -8);
                        pointForMove2 = new Vector3(dx, -(float)Math.Sqrt((longDistance * longDistance) - (dx * dx) - 1), -8);
                    }
                    else
                    {
                        pointForMove1 = new Vector3((float)Math.Sqrt((longDistance * longDistance) - (dy * dy) - 1), dy, -8);
                        pointForMove2 = new Vector3(-(float)Math.Sqrt((longDistance * longDistance) - (dy * dy) - 1), dy, -8);
                    }
                    currDirection = pointForMove2;
                    counterForMove = random3.Next(3, 7);
                    isMove = true;
                }
            }
            if (isRotate)
            {
                var currDeltaX = transform.position.x - target.position.x;
                var currDeltaY = transform.position.y - target.position.y;
                var angle = MathF.Atan2(currDeltaY, currDeltaX);
                angle += directionRotate * speedRotate * Time.deltaTime;
                transform.position = new Vector3((float)(radius * Math.Cos(angle) + target.position.x), (float)(radius * Math.Sin(angle) + target.position.y), -8);
                angleRotate -= speedRotate * Time.deltaTime;              
                if (angleRotate < 0)
                {
                    isRotate = false;
                    dateTimeRot = DateTime.Now;                   
                }
            }
            if (isMove)
            {
                var vector = Vector3.MoveTowards(transform.position, currDirection + target.position, longDistance * Time.fixedDeltaTime);
                vector.z = -8;
                transform.position = vector;
                if (Vector3.Distance(transform.position, currDirection + target.position) < 3)
                {
                    if (Vector3.Distance(transform.position, pointForMove2 + target.position) < 3)
                            currDirection = pointForMove1;
                    if (Vector3.Distance(transform.position, pointForMove1 + target.position) < 3)
                            currDirection = pointForMove2;
                    counterForMove -= 1;                   
                }                
                if (counterForMove <= 0)
                {
                    isMove = false;
                    dateTimeRot = DateTime.Now;                    
                }
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
                bullet.direction = (target.position - transform.position).normalized;               
                Instantiate(bullet, shotPoint.position, transform.rotation);
                isHard = true;
                foreach (var stone in stones)
                {
                    if (stone == null)
                        continue;
                    if (Vector2.Angle(stone.transform.position - transform.position, target.position - transform.position) < 45)
                    {                       
                        isHard = false;
                    }
                        
                    if (Vector2.Distance(stone.transform.position, target.position) > 12 && Vector2.Distance(stone.transform.position, transform.position) > 12)
                    {
                        isHard = true;
                    }
                    if (Vector2.Distance(stone.transform.position, transform.position) < 8)
                    {
                        if (counterorChildren == 2)
                        {
                            Instantiate(children, point1.position, transform.rotation);
                            Instantiate(children, point2.position, transform.rotation);
                            Instantiate(children, point3.position, transform.rotation);
                            Instantiate(children, point4.position, transform.rotation);
                            counterorChildren = 0;
                        }
                        else
                            counterorChildren += 1;
                    }
                        
                }


                if (isHard)
                {
                    var delta = 1.5f;
                    for (int i = 0; i < 10; i++)
                    {
                        Vector2 vector = (target.position - transform.position);
                        var dxDelta = ((random1.NextDouble() * 2* delta) - delta) * Vector2.Distance(target.position, transform.position)/8;
                        var dyDelta = ((random2.NextDouble() * 2* delta) - delta) * Vector2.Distance(target.position, transform.position)/8;
                        vector = new Vector2((float)(dxDelta + vector.x), (float)(dyDelta + vector.y));
                        bullet.direction = vector.normalized;
                        Instantiate(bullet, shotPoint.position, transform.rotation);
                    }
                }
                dateTime = DateTime.Now;
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
