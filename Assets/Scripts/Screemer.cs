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
    public GameObject jellyfish1;
    public GameObject jellyfish2;
    public GameObject jellyfish3;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Playernew").GetComponent<Transform>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (jellyfish1 != null)
        {
            jellyfish1.GetComponent<BotContoller>().distansToAttac = 100;
            jellyfish2.GetComponent<BotContoller>().distansToAttac = 100;
            jellyfish3.GetComponent<BotContoller>().distansToAttac = 100;

            if (jellyfish1.GetComponent<BotContoller>().health <= 0 &&
                jellyfish2.GetComponent<BotContoller>().health <= 0 &&
                jellyfish3.GetComponent<BotContoller>().health <= 0)
            {
                music.SetActive(false);
                Destroy(this.gameObject);
                Glight.SetActive(false);
                Plight.SetActive(true);
            }
        }

        if (Vector2.Distance(transform.position, target.position) < 3)
        {
            sleep.active = false;
            activ.active = true;
            music.SetActive(true);
            Glight.SetActive(true);
            Plight.SetActive(false);

            //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
    }
}
