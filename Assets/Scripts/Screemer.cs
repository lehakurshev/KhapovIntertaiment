using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Screemer : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    public float speed = 5;
    public GameObject sleep;
    public GameObject activ;
    public GameObject player;
    public GameObject music;
    public GameObject Glight;
    public GameObject Plight;
    public GameObject wave;
    public GameObject door;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Playernew").GetComponent<Transform>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        
        if (Vector2.Distance(transform.position, target.position) < 3)
        {
            sleep.active = false;
            activ.active = true;
            music.SetActive(true);
            Glight.SetActive(true);
            Plight.SetActive(false);

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);

        }

            

    }
}
