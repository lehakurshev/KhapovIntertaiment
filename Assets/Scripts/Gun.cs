using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public float timeBtwShorts;
    public float startTime;

    public GameObject bullet;
    public Transform point;
    // Update is called once per frame
    void Update()
    {

        
        if (timeBtwShorts <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, point.position, transform.rotation);

                timeBtwShorts = startTime;
            }

            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ -60);


        }
        else
            timeBtwShorts -= Time.deltaTime;
        
    }
}
