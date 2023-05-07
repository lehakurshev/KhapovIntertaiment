using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float other;
    public float speed;
    public float lifetime;
    public float distanse;
    public float damage;
    public LayerMask whaetIsSolid;

    // Update is called once per frame
    private void Start()
    {
        
        
    }

    void Update()
    {
        

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distanse, whaetIsSolid);
        if (hitInfo.collider != null)
        {
            //if (hitInfo.collider.CompareTag("Enemy"))
            //    hitInfo.collider.GetComponent<enemy>().TakeDamage(damage);
            
            Destroy(gameObject);
        }
        
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
