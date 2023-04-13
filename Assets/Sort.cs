using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Linq;

public class Sort : MonoBehaviour
{
    
    
    public float distance=18;

    //static float[] distanses = { 0,0,0,0,0,0,0,0,0};

    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(GameObject.Find("R0").transform.position, target.position)<10)
        {
            GameObject.Find("R1").transform.position = new Vector3(GameObject.Find("R0").transform.position.x + 16, GameObject.Find("R0").transform.position.y, 5);
            GameObject.Find("R2").transform.position = new Vector3(GameObject.Find("R0").transform.position.x - 16, GameObject.Find("R0").transform.position.y,5);
            GameObject.Find("R3").transform.position = new Vector3(GameObject.Find("R0").transform.position.x + 16, GameObject.Find("R0").transform.position.y + 16,5);
            GameObject.Find("R4").transform.position = new Vector3(GameObject.Find("R0").transform.position.x + 16, GameObject.Find("R0").transform.position.y - 16,5);
            GameObject.Find("R5").transform.position = new Vector3(GameObject.Find("R0").transform.position.x - 16, GameObject.Find("R0").transform.position.y - 16,5);
            GameObject.Find("R6").transform.position = new Vector3(GameObject.Find("R0").transform.position.x - 16, GameObject.Find("R0").transform.position.y + 16,5);
            GameObject.Find("R7").transform.position = new Vector3(GameObject.Find("R0").transform.position.x, GameObject.Find("R0").transform.position.y - 16,5);
            GameObject.Find("R8").transform.position = new Vector3(GameObject.Find("R0").transform.position.x, GameObject.Find("R0").transform.position.y + 16,5);
        }
        if (Vector2.Distance(GameObject.Find("R1").transform.position, target.position) < 10)
        {
            GameObject.Find("R0").transform.position = new Vector3(GameObject.Find("R1").transform.position.x + 16, GameObject.Find("R1").transform.position.y, 5);
            GameObject.Find("R2").transform.position = new Vector3(GameObject.Find("R1").transform.position.x - 16, GameObject.Find("R1").transform.position.y, 5);
            GameObject.Find("R3").transform.position = new Vector3(GameObject.Find("R1").transform.position.x + 16, GameObject.Find("R1").transform.position.y + 16, 5);
            GameObject.Find("R4").transform.position = new Vector3(GameObject.Find("R1").transform.position.x + 16, GameObject.Find("R1").transform.position.y - 16, 5);
            GameObject.Find("R5").transform.position = new Vector3(GameObject.Find("R1").transform.position.x - 16, GameObject.Find("R1").transform.position.y - 16, 5);
            GameObject.Find("R6").transform.position = new Vector3(GameObject.Find("R1").transform.position.x - 16, GameObject.Find("R1").transform.position.y + 16, 5);
            GameObject.Find("R7").transform.position = new Vector3(GameObject.Find("R1").transform.position.x, GameObject.Find("R1").transform.position.y - 16, 5);
            GameObject.Find("R8").transform.position = new Vector3(GameObject.Find("R1").transform.position.x, GameObject.Find("R1").transform.position.y + 16, 5);
        }
        if (Vector2.Distance(GameObject.Find("R2").transform.position, target.position) < 10)
        {
            GameObject.Find("R1").transform.position = new Vector3(GameObject.Find("R2").transform.position.x + 16, GameObject.Find("R2").transform.position.y, 5);
            GameObject.Find("R0").transform.position = new Vector3(GameObject.Find("R2").transform.position.x - 16, GameObject.Find("R2").transform.position.y, 5);
            GameObject.Find("R3").transform.position = new Vector3(GameObject.Find("R2").transform.position.x + 16, GameObject.Find("R2").transform.position.y + 16, 5);
            GameObject.Find("R4").transform.position = new Vector3(GameObject.Find("R2").transform.position.x + 16, GameObject.Find("R2").transform.position.y - 16, 5);
            GameObject.Find("R5").transform.position = new Vector3(GameObject.Find("R2").transform.position.x - 16, GameObject.Find("R2").transform.position.y - 16, 5);
            GameObject.Find("R6").transform.position = new Vector3(GameObject.Find("R2").transform.position.x - 16, GameObject.Find("R2").transform.position.y + 16, 5);
            GameObject.Find("R7").transform.position = new Vector3(GameObject.Find("R2").transform.position.x, GameObject.Find("R2").transform.position.y - 16, 5);
            GameObject.Find("R8").transform.position = new Vector3(GameObject.Find("R2").transform.position.x, GameObject.Find("R2").transform.position.y + 16, 5);
        }
        if (Vector2.Distance(GameObject.Find("R3").transform.position, target.position) < 10)
        {
            GameObject.Find("R1").transform.position = new Vector3(GameObject.Find("R3").transform.position.x + 16, GameObject.Find("R3").transform.position.y, 5);
            GameObject.Find("R2").transform.position = new Vector3(GameObject.Find("R3").transform.position.x - 16, GameObject.Find("R3").transform.position.y, 5);
            GameObject.Find("R0").transform.position = new Vector3(GameObject.Find("R3").transform.position.x + 16, GameObject.Find("R3").transform.position.y + 16, 5);
            GameObject.Find("R4").transform.position = new Vector3(GameObject.Find("R3").transform.position.x + 16, GameObject.Find("R3").transform.position.y - 16, 5);
            GameObject.Find("R5").transform.position = new Vector3(GameObject.Find("R3").transform.position.x - 16, GameObject.Find("R3").transform.position.y - 16, 5);
            GameObject.Find("R6").transform.position = new Vector3(GameObject.Find("R3").transform.position.x - 16, GameObject.Find("R3").transform.position.y + 16, 5);
            GameObject.Find("R7").transform.position = new Vector3(GameObject.Find("R3").transform.position.x, GameObject.Find("R3").transform.position.y - 16, 5);
            GameObject.Find("R8").transform.position = new Vector3(GameObject.Find("R3").transform.position.x, GameObject.Find("R3").transform.position.y + 16, 5);
        }
        if (Vector2.Distance(GameObject.Find("R4").transform.position, target.position) < 10)
        {
            GameObject.Find("R1").transform.position = new Vector3(GameObject.Find("R4").transform.position.x + 16, GameObject.Find("R4").transform.position.y, 5);
            GameObject.Find("R2").transform.position = new Vector3(GameObject.Find("R4").transform.position.x - 16, GameObject.Find("R4").transform.position.y, 5);
            GameObject.Find("R3").transform.position = new Vector3(GameObject.Find("R4").transform.position.x + 16, GameObject.Find("R4").transform.position.y + 16, 5);
            GameObject.Find("R0").transform.position = new Vector3(GameObject.Find("R4").transform.position.x + 16, GameObject.Find("R4").transform.position.y - 16, 5);
            GameObject.Find("R5").transform.position = new Vector3(GameObject.Find("R4").transform.position.x - 16, GameObject.Find("R4").transform.position.y - 16, 5);
            GameObject.Find("R6").transform.position = new Vector3(GameObject.Find("R4").transform.position.x - 16, GameObject.Find("R4").transform.position.y + 16, 5);
            GameObject.Find("R7").transform.position = new Vector3(GameObject.Find("R4").transform.position.x, GameObject.Find("R4").transform.position.y - 16, 5);
            GameObject.Find("R8").transform.position = new Vector3(GameObject.Find("R4").transform.position.x, GameObject.Find("R4").transform.position.y + 16, 5);
        }
        if (Vector2.Distance(GameObject.Find("R5").transform.position, target.position) < 10)
        {
            GameObject.Find("R1").transform.position = new Vector3(GameObject.Find("R5").transform.position.x + 16, GameObject.Find("R5").transform.position.y, 5);
            GameObject.Find("R2").transform.position = new Vector3(GameObject.Find("R5").transform.position.x - 16, GameObject.Find("R5").transform.position.y, 5);
            GameObject.Find("R3").transform.position = new Vector3(GameObject.Find("R5").transform.position.x + 16, GameObject.Find("R5").transform.position.y + 16, 5);
            GameObject.Find("R4").transform.position = new Vector3(GameObject.Find("R5").transform.position.x + 16, GameObject.Find("R5").transform.position.y - 16, 5);
            GameObject.Find("R0").transform.position = new Vector3(GameObject.Find("R5").transform.position.x - 16, GameObject.Find("R5").transform.position.y - 16, 5);
            GameObject.Find("R6").transform.position = new Vector3(GameObject.Find("R5").transform.position.x - 16, GameObject.Find("R5").transform.position.y + 16, 5);
            GameObject.Find("R7").transform.position = new Vector3(GameObject.Find("R5").transform.position.x, GameObject.Find("R5").transform.position.y - 16, 5);
            GameObject.Find("R8").transform.position = new Vector3(GameObject.Find("R5").transform.position.x, GameObject.Find("R5").transform.position.y + 16, 5);
        }
        if (Vector2.Distance(GameObject.Find("R6").transform.position, target.position) < 10)
        {
            GameObject.Find("R1").transform.position = new Vector3(GameObject.Find("R6").transform.position.x + 16, GameObject.Find("R6").transform.position.y, 5);
            GameObject.Find("R2").transform.position = new Vector3(GameObject.Find("R6").transform.position.x - 16, GameObject.Find("R6").transform.position.y, 5);
            GameObject.Find("R3").transform.position = new Vector3(GameObject.Find("R6").transform.position.x + 16, GameObject.Find("R6").transform.position.y + 16, 5);
            GameObject.Find("R4").transform.position = new Vector3(GameObject.Find("R6").transform.position.x + 16, GameObject.Find("R6").transform.position.y - 16, 5);
            GameObject.Find("R5").transform.position = new Vector3(GameObject.Find("R6").transform.position.x - 16, GameObject.Find("R6").transform.position.y - 16, 5);
            GameObject.Find("R0").transform.position = new Vector3(GameObject.Find("R6").transform.position.x - 16, GameObject.Find("R6").transform.position.y + 16, 5);
            GameObject.Find("R7").transform.position = new Vector3(GameObject.Find("R6").transform.position.x, GameObject.Find("R6").transform.position.y - 16, 5);
            GameObject.Find("R8").transform.position = new Vector3(GameObject.Find("R6").transform.position.x, GameObject.Find("R6").transform.position.y + 16, 5);
        }
        if (Vector2.Distance(GameObject.Find("R7").transform.position, target.position) < 10)
        {
            GameObject.Find("R1").transform.position = new Vector3(GameObject.Find("R7").transform.position.x + 16, GameObject.Find("R7").transform.position.y, 5);
            GameObject.Find("R2").transform.position = new Vector3(GameObject.Find("R7").transform.position.x - 16, GameObject.Find("R7").transform.position.y, 5);
            GameObject.Find("R3").transform.position = new Vector3(GameObject.Find("R7").transform.position.x + 16, GameObject.Find("R7").transform.position.y + 16, 5);
            GameObject.Find("R4").transform.position = new Vector3(GameObject.Find("R7").transform.position.x + 16, GameObject.Find("R7").transform.position.y - 16, 5);
            GameObject.Find("R5").transform.position = new Vector3(GameObject.Find("R7").transform.position.x - 16, GameObject.Find("R7").transform.position.y - 16, 5);
            GameObject.Find("R6").transform.position = new Vector3(GameObject.Find("R7").transform.position.x - 16, GameObject.Find("R7").transform.position.y + 16, 5);
            GameObject.Find("R0").transform.position = new Vector3(GameObject.Find("R7").transform.position.x, GameObject.Find("R7").transform.position.y - 16, 5);
            GameObject.Find("R8").transform.position = new Vector3(GameObject.Find("R7").transform.position.x, GameObject.Find("R7").transform.position.y + 16, 5);
        }
        if (Vector2.Distance(GameObject.Find("R8").transform.position, target.position) < 10)
        {
            GameObject.Find("R1").transform.position = new Vector3(GameObject.Find("R8").transform.position.x + 16, GameObject.Find("R8").transform.position.y, 5);
            GameObject.Find("R2").transform.position = new Vector3(GameObject.Find("R8").transform.position.x - 16, GameObject.Find("R8").transform.position.y, 5);
            GameObject.Find("R3").transform.position = new Vector3(GameObject.Find("R8").transform.position.x + 16, GameObject.Find("R8").transform.position.y + 16, 5);
            GameObject.Find("R4").transform.position = new Vector3(GameObject.Find("R8").transform.position.x + 16, GameObject.Find("R8").transform.position.y - 16, 5);
            GameObject.Find("R5").transform.position = new Vector3(GameObject.Find("R8").transform.position.x - 16, GameObject.Find("R8").transform.position.y - 16, 5);
            GameObject.Find("R6").transform.position = new Vector3(GameObject.Find("R8").transform.position.x - 16, GameObject.Find("R8").transform.position.y + 16, 5);
            GameObject.Find("R7").transform.position = new Vector3(GameObject.Find("R8").transform.position.x, GameObject.Find("R8").transform.position.y - 16, 5);
            GameObject.Find("R0").transform.position = new Vector3(GameObject.Find("R8").transform.position.x, GameObject.Find("R8").transform.position.y + 16, 5);
        }
    }
}
