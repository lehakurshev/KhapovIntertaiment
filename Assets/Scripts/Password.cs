using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Password : MonoBehaviour
{
    string Code = "314";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;
    public GameObject door;
    public GameObject doorPoint;
    public GameObject wave;
    public GameObject E;
    public GameObject Sound;

    public void CodeFunction(string Numbers)
    {
        NrIndex++;

        Nr = Nr + Numbers;
        UiText.text = Nr;

    }
    public void Enter()
    {
        if (Nr == Code)
        {
            door.SetActive(false);
            doorPoint.SetActive(false);
            wave.SetActive(false);
            E.SetActive(false);
            if(Sound!= null)
            {
                Sound.SetActive(true);
            }
            
        }
    }
    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}