using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

public class MainMenu_StartGame : MonoBehaviour
{
    public UnityEngine.UI.Button yourButton;
    public Animator animator;
    private UnityEngine.UI.Button btn;
    [SerializeField] private AudioSource thunder;
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject changeLevel;

    void Start()
    {
        btn = yourButton.GetComponent<UnityEngine.UI.Button>();
    }

    private void Update()
    {
        btn.onClick.AddListener(TaskOnClick);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("light") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            TaskOnNotClick();
            
    }

    private void TaskOnNotClick()
    {
        if (btn.GetComponent<UnityEngine.UI.Button>().name != "startGame")
            return;
    }

    private void TaskOnClick()
    {
        animator.SetBool("isClick", true);

        if (btn.GetComponent<UnityEngine.UI.Button>().tag == "startGame")
            thunder.Play();
        StartCoroutine(WaitForStateExit());
    }

    private IEnumerator WaitForStateExit()
    {
        yield return new WaitForSeconds(2.3f);
        if (btn.GetComponent<UnityEngine.UI.Button>().tag == "startGame")
        {
            buttons.SetActive(false);
            changeLevel.SetActive(true);
            animator.SetBool("isClick", false);
        }
    }
}