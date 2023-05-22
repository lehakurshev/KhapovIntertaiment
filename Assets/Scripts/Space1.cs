using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space1 : MonoBehaviour
    
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            transform.position = new Vector3(1000f, 1000f, 0f);
    }
}
