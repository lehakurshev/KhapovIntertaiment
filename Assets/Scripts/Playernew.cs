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
using System.Runtime.InteropServices;
using UnityEngine.Rendering.Universal;

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
    public GameObject GlobalLight;
    public GameObject WalkSound;

    public float health = 500;
    public GameObject healthGameObject;
    public GameObject circle_left;
    public GameObject circle_up;
    public GameObject circle_down;
    public LayerMask enemies;
    private float damage = 20f;

    static double time = 0;

    public float D = 1;
    public float M = 1;
    public float F = 1;
    //public Texture2D cursorTexture;

    public GameObject bloodConv;
    public float V;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        F = (healthGameObject.transform.localScale.x);
        //UnityEngine.Cursor.SetCursor(cursorTexture, new Vector2(10,10), CursorMode.Auto);
    }

    [Obsolete]
    private void FixedUpdate()
    {
        //UnityEngine.Cursor.SetCursor(cursorTexture, new Vector2(10, 10), CursorMode.Auto);
        D =(health / 5000);
        var col = bloodConv.GetComponent<SpriteRenderer>();
        col.color= new UnityEngine.Color(1,1,1,1-D);
        M = (healthGameObject.transform.localScale.x) * D;

        healthGameObject.transform.localScale = new Vector2(F*D, healthGameObject.transform.localScale.y);

        if (health<= 0) 
        {
            GetComponent<Pause>().GetPause();
            //GameOverPNG.SetActive(true);
            //GlobalLight.SetActive(true);
        }
        
        


        if (Input.GetKey(KeyCode.Space))
            Light.GetComponent<Light2D>().intensity = 1;
        else
            Light.GetComponent<Light2D>().intensity = 0.06f;

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
        //GetComponent<Renderer>().material.color = new UnityEngine.Color(1, 0, 0);

    }

    
}
