using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textG;
    [SerializeField] private GameObject loadLevel;
    [SerializeField] private GameObject writeMachine;
    private string text;
    private string sign;

    private void OnEnable()
    {
        text = textG.text;
        textG.text = "";
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        loadLevel.SetActive(true);
        yield return new WaitForSeconds(2.2f);
        writeMachine.SetActive(true);
        foreach (var abc in text)
        {
            textG.text += abc;
            sign = abc.ToString();

            if (sign == "." || 
                sign == "," || 
                sign == "!" || 
                sign == "?")
                yield return new WaitForSeconds(0.2f);
            else
                yield return new WaitForSeconds(0.05f);
        }
        writeMachine.SetActive(false);
    }
}