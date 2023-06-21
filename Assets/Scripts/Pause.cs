using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool GamePause = false;
    private GameObject stopePause;
    private GameObject stopeDeath;
    private GameObject[] screemers;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject screem;
    [SerializeField] private GameObject walk;
    [SerializeField] private GameObject manage;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject swordSound;
    [SerializeField] private AudioSource acheSound;
    [SerializeField] private UnityEngine.UI.Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        stopePause = GameObject.Find("PauseCanvas");
        stopeDeath = GameObject.Find("DeathCanvas");
        Time.timeScale = 1f;
        stopePause.SetActive(false);
        if(stopeDeath != null)
            stopeDeath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && 
            (stopeDeath == null ||
            !stopeDeath.active))
            GetPause();

        if (player.GetComponent<Playernew>().health <= 0 &&
            stopeDeath != null &&
            !stopeDeath.active)
            GetDeath();
    }

    private void GetDeath()
    {
        stopePause.SetActive(false);
        if (screem != null && screem.active)
            screem.GetComponent<AudioSource>().volume = 0f;
        walk.SetActive(false);
        player.GetComponent<AudioSource>().volume = 0f;
        swordSound.GetComponent<AudioSource>().volume = 0f;
        acheSound.volume = 0f;
        stopeDeath.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GetPause()
    {
        if (!GamePause)
        {
            if (screem != null && screem.active)
                screem.GetComponent<AudioSource>().volume = 0f;
            walk.SetActive(false);
            player.GetComponent<AudioSource>().volume = 0f;
            stopePause.SetActive(true);
            swordSound.GetComponent<AudioSource>().volume = 0f;
            acheSound.volume = 0f;
            Time.timeScale = 0f;
            GamePause = true;
        }
        else if (GameObject.Find("_side walk_0").GetComponent<Playernew>().health>0)
        {
            if (screem != null)
                screem.GetComponent<AudioSource>().volume = slider.value * 0.4f;
            walk.SetActive(true);
            player.GetComponent<AudioSource>().volume = slider.value * 0.4f;
            swordSound.GetComponent<AudioSource>().volume = slider.value * 0.4f;
            acheSound.volume = slider.value * 0.4f;
            manage.SetActive(false);
            settings.SetActive(false);
            buttons.SetActive(true);
            stopePause.SetActive(false);
            Time.timeScale = 1f;
            GamePause = false;
        }
    }
}
