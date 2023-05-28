using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    public void GOTO_Next_Scene()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentScene + 1);
        SceneManager.LoadScene(currentScene + 1);
    }
}
