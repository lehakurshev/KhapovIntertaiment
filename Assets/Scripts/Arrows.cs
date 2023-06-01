using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField] private GameObject arrows;
    [SerializeField] private Animator gate;
    [SerializeField] private GameObject goNext;

    void Update()
    {
        var bosses = GameObject.FindGameObjectsWithTag("Boss");
        if(bosses.Length == 0)
        {
            arrows.SetActive(true);
            gate.SetBool("isEnd", true);
            goNext.SetActive(true);
        }
    }

}
