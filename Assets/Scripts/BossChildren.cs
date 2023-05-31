using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossChildren : MonoBehaviour
{
    Transform target;
    public Rigidbody2D rb2d;
    public Playernew player;
    public float speed;
    public float health;
    public float maxHealth;
    private Vector2 directionPlayer;

    private static TimeSpan deltaForAttack;
    private DateTime startAttack;

    //Start is called before the first frame update
    void Start()
    {
        target = player.GetComponent<Transform>();
        deltaForAttack = new TimeSpan(0, 0, 0, 1, 0);
        health = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.direction.x != 0 || player.direction.y != 0)
            directionPlayer = player.direction.normalized;
        if (Vector2.Distance(transform.position, target.position) < 2 && Input.GetKey(KeyCode.Mouse0))
        {;
            var vector1 = new Vector2(transform.position.x - target.position.x, transform.position.y - target.position.y);
            if (Vector2.Angle(vector1,directionPlayer) < 45 && (DateTime.Now - startAttack > deltaForAttack))
            {
                var directionImpulse = (transform.position - target.position).normalized;
                rb2d.AddForce(directionImpulse * 60000, ForceMode2D.Impulse);
                TakeDamage(1);
                startAttack = DateTime.Now;
            }
        }
        else if (Vector2.Distance(transform.position, target.position) < 1.5)
        {         
            player.TakeDamage(5, true);
        }
        else
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        //GetComponent<Renderer>().material.color = new UnityEngine.Color(1, 0, 0);
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
