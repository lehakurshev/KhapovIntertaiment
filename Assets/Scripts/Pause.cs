using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool GamePause = false;
    private GameObject stope;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject manage;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject buttons;
    // Start is called before the first frame update
    void Start()
    {
        stope = GameObject.Find("PauseCanvas");
        stope.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GetPause();
    }

    public void GetPause()
    {
        if (!GamePause)
        {
            player.GetComponent<AudioSource>().volume = 0.0f;
            stope.SetActive(true);
            Time.timeScale = 0f;
            GamePause = true;
        }
        else if (GameObject.Find("_side walk_0").GetComponent<Playernew>().health>0)
        {
            player.GetComponent<AudioSource>().volume = 0.2f;
            manage.SetActive(false);
            settings.SetActive(false);
            buttons.SetActive(true);
            stope.SetActive(false);
            Time.timeScale = 1f;
            GamePause = false;
        }
    }
}
