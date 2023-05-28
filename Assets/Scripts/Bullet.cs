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

    public Vector2 direction;

    // Update is called once per frame
    private void Start()
    {
        
        
    }

    void Update()
    {
        

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, distanse, whaetIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                var player = hitInfo.collider.GetComponent<Player>();
                Destroy(player);
            }               
            
            Destroy(gameObject);
        }
        
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
