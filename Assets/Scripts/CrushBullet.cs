using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrushBullet : MonoBehaviour
{
    private static TimeSpan deltaForDispose;
    private DateTime startDispose;
    public
    // Start is called before the first frame update
    void Start()
    {
        deltaForDispose = new TimeSpan(0, 0, 0, 0, 15);
        startDispose = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now - startDispose > deltaForDispose)
        {
            var hitInfo = Physics2D.OverlapCircleAll(transform.position, 20);
            if (hitInfo.Length > 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
