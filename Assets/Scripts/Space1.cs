using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            transform.position = new Vector3(1000f, 1000f, 0f);
    }
}
