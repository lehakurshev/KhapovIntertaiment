using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private float health;
    public Animator animator;

    private bool IsDispose;
    private static TimeSpan deltaForDispose;
    private DateTime startDispose;
    // Start is called before the first frame update
    void Start()
    {
        health = 2f;
        deltaForDispose = new TimeSpan(0, 0, 0, 1, 0);
    }

    public void FixedUpdate() 
    {
        if (IsDispose && (DateTime.Now - startDispose > deltaForDispose))
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    public void TakeDamage() 
    {
        if (health == 1f)
        {
            health = 0f;
            animator.SetFloat("health", 0f);
            IsDispose = true;
            startDispose = DateTime.Now;
        }
        else if (health == 2f)
        {
            health = 1f;
            animator.SetFloat("health", 1f);
        }        
    }

}
