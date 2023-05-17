using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
using static Unity.Burst.Intrinsics.X86.Sse4_2;
using static UnityEngine.EventSystems.EventTrigger;
using System.Drawing;

public class Playernew : MonoBehaviour
{
    
    
    public float speed = 5f;
    public bool isFacingRight = false;
    public Vector2 direction;
    public Animator animator;
    Transform target;
    [SerializeField] 
    private Rigidbody2D rb;
    public GameObject Light;
    public GameObject WalkSound;

    public float health = 500000;

    public GameObject circle_left;
    public GameObject circle_up;
    public GameObject circle_down;
    public LayerMask enemies;
    private float damage = 20f;

    static double time = 0;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    [Obsolete]
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
                Light.active = false;
        else
            Light.active = true;

        if (Input.GetKey(KeyCode.Mouse0))
        { 
            if (time == 0 || Time.time>=time+0.5)
            {

                Attack();
                animator.SetBool("isAttack", true);
                time = Time.time;
            }
        }

        else if (Time.time >= time + 0.5)
        {
            animator.SetBool("isAttack", false);

            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            //if (Input.GetAxisRaw("Horizontal")==0)
            //    direction.y = Input.GetAxisRaw("Vertical");
                       
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Speed", direction.sqrMagnitude);
            
            Flip();

            rb.MovePosition(rb.position + direction.normalized * speed * Time.fixedDeltaTime);

            if ((direction.x != 0 || direction.y != 0 ) && !Input.GetKey(KeyCode.Mouse0))
                WalkSound.SetActive(true);
            else
                WalkSound.SetActive(false);
        }
        
        
    }

    private void Flip()
    {
        if (isFacingRight && direction.x < 0f || !isFacingRight && direction.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void Attack()
    {
        GameObject circle = circle_left;
        if (string.Compare(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, "walk_down") == 0 || string.Compare(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, "idle_down") == 0)
        {
            circle = circle_down;
        }
        else if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "idle_up" || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "walk_up")
        {
            circle = circle_up;
        }


        var enemy = Physics2D.OverlapCircleAll(circle.transform.position, 0.75f, enemies);
        foreach (var e in enemy)
        {
            e.GetComponent<BotContoller>().TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage,bool isdamage) 
    {
        health-=damage;
    }

    
}
