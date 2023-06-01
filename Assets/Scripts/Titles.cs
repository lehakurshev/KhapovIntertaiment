using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titles : MonoBehaviour
{
    [SerializeField] private Animator titles;

    void Update()
    {
        if (titles.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex - 1);
            SceneManager.LoadScene(0);
        }
    }
}
