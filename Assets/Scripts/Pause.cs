using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool GamePause = false;
    private GameObject stope;
    // Start is called before the first frame update
    void Start()
    {
        stope = GameObject.Find("CanvasPause");
        stope.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetPause();
        }
    }

    public void GetPause()
    {
        
            if (!GamePause)
            {
                stope.SetActive(true);
                Time.timeScale = 0f;
                GamePause = true;
            }
            else if (GameObject.Find("_side walk_0").GetComponent<Playernew>().health>0)
            {
                stope.SetActive(false);
                Time.timeScale = 1f;
                GamePause = false;
            }
        
    }
}
