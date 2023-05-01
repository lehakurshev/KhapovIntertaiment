using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotContoller : MonoBehaviour
{
    public Transform playerTr;
    NavMeshAgent agent;
    public double helth=5000;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0) && Vector2.Distance(Enemy.transform.position, playerTr.position) < 2)
        {
            helth--;
        }
        if (helth == 0)
            Enemy.active = false;
        agent.SetDestination(playerTr.position);


        bool asi = GameObject.Find("_side walk_0").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack_side_idle");
        bool asi2 = GameObject.Find("_side walk_0").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack_down_idle");
        bool asi3 = GameObject.Find("_side walk_0").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack_down_walk");
        bool asi4 = GameObject.Find("_side walk_0").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack_side_walk");
        bool asi5 = GameObject.Find("_side walk_0").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack_up_idle");
        bool asi6 = GameObject.Find("_side walk_0").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack_up_walk");

        var S = asi || asi2 || asi3 || asi4 || asi5 || asi6;

        if (S && Vector2.Distance(Enemy.transform.position, playerTr.position) < 2 )
        {
            Enemy.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
            Enemy.transform.position= Vector2.MoveTowards(transform.position, playerTr.transform.position, -2*Time.fixedDeltaTime);
            
        }
        else
        {
            Enemy.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
    }
}