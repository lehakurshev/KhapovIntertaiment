using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mause1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            mause1.SetActive(false);

    }
}
