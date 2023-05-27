using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Button : MonoBehaviour
{

    public Transform box;
    public GameObject door;
    public GameObject button;
    public GameObject sound;
    public float length=1f;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Vector2.Distance(transform.position, box.position) < length)
        {
            door.active = false;
            button.active = true;
            sound.SetActive(true);

        }


        else 
        {
            door.active = true;
            button.active = false;
            sound.SetActive(false);
        }

            
    }
}
