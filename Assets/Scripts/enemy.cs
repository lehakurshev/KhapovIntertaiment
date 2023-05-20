using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health;
    //public bool aggressive = false;
    public float speed = 1f;
    public float distance = 3;
    Transform target;
    public GameObject Point1;
    public GameObject Point2;
    public GameObject player;
    private bool a = true;

    // Start is called before the first frame update
    void Start()
    {
        
        //if (Vector2.Distance(transform.position, target.position) < 1)
            target = GameObject.FindGameObjectWithTag("Playernew").GetComponent<Transform>();

        health = 60;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            distance = 1;
        else
            distance = 3;
        //if(Vector2.Distance(transform.position, target.position) < distance)
        //aggressive= true;
        if (Vector2.Distance(transform.position, target.position) < 0.6)
            player.active = false;
        if (Vector2.Distance(transform.position, target.position) > distance && Vector2.Distance(transform.position, Point1.transform.position) > 0.1 && a)
            transform.position = Vector2.MoveTowards(transform.position, Point1.transform.position, speed * Time.fixedDeltaTime);
        else if (Vector2.Distance(transform.position, target.position) > distance && Vector2.Distance(transform.position, Point2.transform.position) > 0.1)
        {
            a = false;
            transform.position = Vector2.MoveTowards(transform.position, Point2.transform.position, speed * Time.fixedDeltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) > distance)
            a = true;
        else
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
