using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{

    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject screem;

    public void UnPause()
    {
        if (screem != null && screem.active)
            screem.GetComponent<AudioSource>().volume = 0.5f;
        pause.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<Pause>().GamePause = false;
        player.GetComponent<AudioSource>().volume = 0.2f;
    }
}
