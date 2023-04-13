using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Screemer : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    public float speed = 3;
    public GameObject sleep;
    public GameObject activ;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        
        if (Vector2.Distance(transform.position, target.position) < 3)
        {
            sleep.active = false;
            activ.active = true;
            
        }
            

    }
}
