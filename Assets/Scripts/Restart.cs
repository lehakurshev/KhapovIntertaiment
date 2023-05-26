using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject player;
    public void RestartLevel()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<Pause>().GamePause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
