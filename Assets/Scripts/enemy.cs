using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;
    //public bool aggressive = false;
    public float Speed = 1f;
    public float Distance = 3;
    Transform target;
    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;
    [SerializeField] private GameObject player;
    private bool isAggresive = true;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Playernew").GetComponent<Transform>();
        Health = 60;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Distance = 1;
        else
            Distance = 3;
        //if(Vector2.Distance(transform.position, target.position) < distance)
        //aggressive= true;
        if (Vector2.Distance(transform.position, target.position) < 0.6)
            player.active = false;
        if (Vector2.Distance(transform.position, target.position) > Distance && Vector2.Distance(transform.position, point1.transform.position) > 0.1 && isAggresive)
            transform.position = Vector2.MoveTowards(transform.position, point1.transform.position, Speed * Time.fixedDeltaTime);
        else if (Vector2.Distance(transform.position, target.position) > Distance && Vector2.Distance(transform.position, point2.transform.position) > 0.1)
        {
            isAggresive = false;
            transform.position = Vector2.MoveTowards(transform.position, point2.transform.position, Speed * Time.fixedDeltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) > Distance)
            isAggresive = true;
        else
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.fixedDeltaTime);
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
