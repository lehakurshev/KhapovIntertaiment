using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField] private Animator gate;
    [SerializeField] private GameObject goNext;
    [SerializeField] private GameObject player;
    private bool isEnd = false;

    void Update()
    {
        var bosses = GameObject.FindGameObjectsWithTag("Boss");
        if(bosses.Length == 0 && !isEnd)
        {
            isEnd = true;
            gate.SetBool("isEnd", true);
            goNext.SetActive(true);
            player.transform.Translate(gate.transform.position.x - player.transform.position.x, 
                gate.transform.position.y - player.transform.position.y - 5,
                gate.transform.position.y - player.transform.position.z);
        }
    }

}
