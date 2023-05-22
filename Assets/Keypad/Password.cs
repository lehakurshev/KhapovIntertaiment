using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Password : MonoBehaviour
{
    string Code = "123";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;
    public GameObject door;
    

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
           
        }
    }
    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}