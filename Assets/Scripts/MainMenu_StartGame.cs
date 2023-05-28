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
    [SerializeField] private UnityEngine.UI.Button settings;
    [SerializeField] private UnityEngine.UI.Button help;
    [SerializeField] private UnityEngine.UI.Button quit;

    void Start()
    {
        btn = yourButton.GetComponent<UnityEngine.UI.Button>();
    }

    private void Update()
    {
        btn.onClick.AddListener(TaskOnClick);     
    }

    private void TaskOnClick()
    {
        animator.SetBool("isClick", true);

        if (btn.GetComponent<UnityEngine.UI.Button>().tag == "startGame")
        {
            thunder.Play();
            btn.enabled = false;
            settings.enabled = false;
            help.enabled = false;
            quit.enabled = false;
        }
        StartCoroutine(WaitForStateExit());
    }

    private IEnumerator WaitForStateExit()
    {
        yield return new WaitForSeconds(2.3f);
        if (btn.GetComponent<UnityEngine.UI.Button>().tag == "startGame")
        {
            btn.enabled=true;
            settings.enabled=true;
            help.enabled=true;
            quit.enabled=true;
            buttons.SetActive(false);
            changeLevel.SetActive(true);
            animator.SetBool("isClick", false);
        }
    }
}