using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using System.Runtime.InteropServices;

public class BotContoller : MonoBehaviour
{
    public Transform playerTr;
    NavMeshAgent agent;
    public double helth=5000;
    public GameObject Center;
    public GameObject Enemy;
    public GameObject Music;
    public GameObject Glight;
    public GameObject Plight;
    public GameObject[] Points;
    Vector2 RandomPoint;
    static bool IsInPoint = false;
    static int Point;
    static bool IsActive=false;
    static bool IsPassive;

    public float redShade = 1f;

    public Animator animator;

    public float health = 50;

    public LayerMask player;

    public GameObject playerObject;

    public float distansToAttac = 1;

    public GameObject damagSound;

    private bool flag = false;
    private bool flag1 = false;

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
        // 100 - ������ �������� ��� ������� ��������
        // ���� ��� ������ ������ ��������� ��������, �� ����� �������� ����� �����
        //if (Input.GetKey(KeyCode.Space) && distansToAttac != 100)
        //    distansToAttac = 3;
        //else if (distansToAttac != 100)
        //    distansToAttac = 1;
        if (distansToAttac != 100)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (!flag)
                {
                    //Passward.SetActive(true);
                    flag1 = true;
                    distansToAttac = 3;

                }

                else
                {

                    flag1 = false;
                    distansToAttac = 1;
                }
            }
            else
            {
                if (!flag && flag1)
                {

                    flag = true;
                    flag1 = true;
                    distansToAttac = 3;
                }
                else if (!flag1)
                {

                    flag = false;
                    distansToAttac = 1;
                }

            }
        }

        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            Enemy.GetComponent<Collider2D>().enabled = false;
            Enemy.GetComponent<NavMeshAgent>().enabled = false;
            return;
        }

        //if (Input.GetKey(KeyCode.Mouse0) && Vector2.Distance(Enemy.transform.position, playerTr.position) < 2)
        //{
        //    helth--;
        //}
        if (helth < 0)
        {
            Enemy.active = false;
            //Music.active= false;
            
            //Glight.SetActive(false);
            Plight.SetActive(true);
            //helth = 5000;

        }

        if ((Vector2.Distance(transform.position, playerTr.position) < distansToAttac))
            IsActive = true;
        else
            IsActive = false;
        if (IsActive)
            agent.SetDestination(playerTr.position);
        else if (!IsInPoint)
        {
            Point = Random.Range(0, Points.Length - 1);
            
            IsInPoint = true;
        }
        else
        {
            if (Vector2.Distance(transform.position, Points[Point].transform.position) > 0.6)
                agent.SetDestination(Points[Point].transform.position);
            else
                IsInPoint = false;
        }

        var Player = Physics2D.OverlapCircleAll(playerTr.position, 10000f, player);
        if (!playerObject.GetComponent<Pause>().GamePause)
        {
            foreach (var p in Player)
            {
                if (Vector2.Distance(Enemy.transform.position, Center.transform.position) < 1)
                {
                    p.GetComponent<Playernew>().TakeDamage(6, true);

                }
                else
                    p.GetComponent<Playernew>().TakeDamage(0, false);


            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Enemy.GetComponent<Renderer>().material.color = new Color(redShade, 0, 0);
        redShade = redShade - (redShade - 0.33 > 0 ? 0.33f : 0f);

        agent.speed += 1f;
        Enemy.transform.localScale = Enemy.transform.localScale * 1.2f;
    }

}