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
    public GameObject music;
    public GameObject Glight;
    public GameObject Plight;
    public GameObject[] jellyfish;
    public GameObject gate;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Playernew").GetComponent<Transform>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        var k = 0;
        foreach (var j in jellyfish)
        {
            if (j.GetComponent<BotContoller>().health <= 0)
                k++;
        }
        if (k == jellyfish.Length)
        {
            music.SetActive(false);
            Glight.SetActive(false);
            Plight.SetActive(true);
            Destroy(this.gameObject);

        }

        if (Vector2.Distance(transform.position, target.position) < 3.2)
        {
            sleep.active = false;
            activ.active = true;
            music.SetActive(true);
            Glight.SetActive(true);
            Plight.SetActive(false);
            if (gate != null)
                gate.SetActive(false);

            foreach (var j in jellyfish)
            {
                j.GetComponent<BotContoller>().distansToAttac = 100;
            }
            //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
    }
}
