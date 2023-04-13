using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public float speed = 5f;
    public Rigidbody2D rb;
    Vector2 move;
    private Animator animator;
    private bool facingLeft = true;
    void FixedUpdate()
    {

        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        //var flipped = move.x < 0;
        //this.transform.rotation = Quaternion.Euler(new Vector3(flipped ? 180f : 0f, 0f, flipped ? 180f : 0f));

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        if (!facingLeft && move.x > 0 || facingLeft && move.x < 0)
            Flip();
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        var scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
