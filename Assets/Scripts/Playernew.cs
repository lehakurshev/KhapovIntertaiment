using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class Playernew : MonoBehaviour
{
    
    public float health;
    public float speed = 5f;
    public bool isFacingRight = false;
    public Vector2 direction;
    public Animator animator;
    Transform target;
    [SerializeField] private Rigidbody2D rb;
    public GameObject light;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    [Obsolete]
    private void FixedUpdate()
    {
        
        if(Input.GetKey(KeyCode.Space))
                light.active = false;
        else
            light.active = true;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        Flip();

        rb.MovePosition(rb.position + direction.normalized * speed * Time.fixedDeltaTime);
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
}
