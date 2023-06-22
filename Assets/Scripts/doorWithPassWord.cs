using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithPassWord : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject password;
    [SerializeField] private GameObject player;
    private bool flag = false;
    private bool flag1 = false;
    [SerializeField] private GameObject E;
    [SerializeField] private GameObject sound;

    void Update()
    {
        
        if (Vector2.Distance(transform.position, player.transform.position) < 3)
        {
            E.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                if (!flag)
                {
                    password.SetActive(true);
                    flag1= true;
                    E.SetActive(false);
                    if (sound != null)
                        sound.GetComponent<AudioSource>().volume= 0;    
                }
                else
                {
                    password.SetActive(false);
                    flag1= false;
                    E.SetActive(true);
                    if (sound!=null)
                        sound.GetComponent<AudioSource>().volume = 0.3f;
                }
            }
            else
            {
                if (!flag && flag1)
                {
                    password.SetActive(true);
                    flag = true;
                    flag1= true;
                    E.SetActive(false);
                    if (sound != null)
                        sound.GetComponent<AudioSource>().volume = 0;
                }
                else if (!flag1)
                {
                    password.SetActive(false);
                    flag = false;
                    E.SetActive(true);
                    if (sound != null)
                        sound.GetComponent<AudioSource>().volume = 0.3f;
                }
            }        
        }
        else
        {
            password.SetActive(false);
            E.SetActive(false);
        }
    }
}

