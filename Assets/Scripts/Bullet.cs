using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distanse;
    public float damage;

    public Vector2 direction;

    private bool IsDispose;
    private static TimeSpan deltaForDispose;
    private DateTime startDispose;

    public Animator animator;
    public CrushBullet crushBullet;

    // Update is called once per frame
    private void Start()
    {
        deltaForDispose = (new TimeSpan(0, 0, 1)/6.6);
        IsDispose = false;
        var rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        direction = new Vector2(1, 0);
    }

    void Update()
    {
        if (IsDispose)
        {
            if (DateTime.Now - startDispose > deltaForDispose)          
                Destroy(gameObject);
        }
        else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, distanse);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Playernew"))
                {
                    var player = hitInfo.collider.GameObject();
                    player.SetActive(false);
                }
                if (hitInfo.collider.CompareTag("Stone"))
                {
                    var stone = hitInfo.collider.GetComponent<Stone>();
                    stone.TakeDamage();

                }
                animator.SetBool("a", true);
                IsDispose = true;
                startDispose = DateTime.Now;
            }
            transform.Translate(direction * speed * Time.deltaTime);
        }         
    }

}
