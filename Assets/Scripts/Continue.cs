using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{

    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject player;
    public void UnPause()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<Pause>().GamePause = false;
        player.GetComponent<AudioSource>().volume = 0.2f;
    }
}
