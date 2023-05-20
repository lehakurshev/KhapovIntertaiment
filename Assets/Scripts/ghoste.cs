using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ghoste : MonoBehaviour
{
    Transform target;
    public float speed = 3;
    public Rigidbody2D rb2d;
    public bool isFacingRight = false;
    static double time = 0;
    public GameObject[] Points;
    public float distansToAttac = 20;
    static bool IsActive = false;
    static bool IsInPoint = false;
    static int Point;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Playernew").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            distansToAttac = 3;
        else
            distansToAttac = 10;

        if ((Vector2.Distance(transform.position, target.position) < distansToAttac))
            IsActive = true;
        else
            IsActive = false;

        if (IsActive)
        {
            if (Input.GetKey(KeyCode.Mouse0) && Vector2.Distance(transform.position, target.position) < 2)
            {
                var directionImpulse = (transform.position - target.position).normalized;
                rb2d.AddForce(directionImpulse * 20000, ForceMode2D.Impulse);
                time = Time.time;
            }
            else
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
        else if (!IsInPoint)
        {
            Point = Random.Range(0, Points.Length - 1);

            IsInPoint = true;
        }
        else
        {
            if (Vector2.Distance(transform.position, Points[Point].transform.position) > 0.6)
                transform.position = Vector2.MoveTowards(transform.position, Points[Point].transform.position, speed * Time.fixedDeltaTime);
            else
                IsInPoint = false;
        }


        

        
    }


    
}
