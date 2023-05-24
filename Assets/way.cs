using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class way : MonoBehaviour
{
    public GameObject Player;
    public GameObject Out;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) < 2 && Input.GetKey(KeyCode.E))
            Player.transform.position = new Vector3(Out.transform.position.x, Out.transform.position.y, Player.transform.position.z);
    }
}
