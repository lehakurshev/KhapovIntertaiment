using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool GamePause = false;
    private GameObject stope;
    private GameObject[] screemers;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject screem;
    [SerializeField] private GameObject walk;
    [SerializeField] private GameObject manage;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject swordSound;
    [SerializeField] private UnityEngine.UI.Slider slider;

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
            if (screem != null && screem.active)
                screem.GetComponent<AudioSource>().volume = 0f;
            walk.SetActive(false);
            player.GetComponent<AudioSource>().volume = 0f;
            stope.SetActive(true);
            swordSound.GetComponent<AudioSource>().volume = 0f;
            Time.timeScale = 0f;
            GamePause = true;
            
        }
        else if (GameObject.Find("_side walk_0").GetComponent<Playernew>().health>0)
        {
            if (screem != null)
                screem.GetComponent<AudioSource>().volume = slider.value * 0.2f;
            walk.SetActive(true);
            player.GetComponent<AudioSource>().volume = slider.value * 0.2f;
            swordSound.GetComponent<AudioSource>().volume = slider.value * 0.2f;
            manage.SetActive(false);
            settings.SetActive(false);
            buttons.SetActive(true);
            stope.SetActive(false);
            Time.timeScale = 1f;
            GamePause = false;
        }
    }
}
