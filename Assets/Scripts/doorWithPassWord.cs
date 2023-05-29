using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorWithPassWord : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Passward;
    public GameObject Player;
    private bool flag = false;
    private bool flag1 = false;
    public GameObject E;
    public GameObject sound;

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, Player.transform.position) < 3)
        {
            E.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                if (!flag)
                {
                    Passward.SetActive(true);
                    flag1= true;
                    E.SetActive(false);
                    if (sound != null)
                        sound.GetComponent<AudioSource>().volume= 0;    
                }

                else
                {
                    Passward.SetActive(false);
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
                    Passward.SetActive(true);
                    flag = true;
                    flag1= true;
                    E.SetActive(false);
                    if (sound != null)
                        sound.GetComponent<AudioSource>().volume = 0;
                }
                else if (!flag1)
                {
                    Passward.SetActive(false);
                    flag = false;
                    E.SetActive(true);
                    if (sound != null)
                        sound.GetComponent<AudioSource>().volume = 0.3f;
                }
                
            }
                    
        }
        else
        {
            Passward.SetActive(false);
            E.SetActive(false);
            
        }
            
    }
}

