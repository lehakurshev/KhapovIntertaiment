using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnityEngine.UI.Button button;

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(TaskOnClick);
        
    }

    private void TaskOnClick()
    {
        animator.SetBool("isClick", true);
    }
}
