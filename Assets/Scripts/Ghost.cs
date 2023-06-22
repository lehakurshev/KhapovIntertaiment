using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Ghost : MonoBehaviour
{
    Transform target;
    public float Speed = 3;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private bool isFacingRight = false;
    static double Time = 0;
    public GameObject[] Points;
    [SerializeField] private float distansToAttac = 20;
    static bool IsActive = false;
    static bool IsInPoint = false;
    static int Point;

    private bool flag = false;
    private bool flag1 = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Playernew").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!flag)
            {
                //Passward.SetActive(true);
                flag1 = true;
                distansToAttac = 10;

            }

            else
            {

                flag1 = false;
                distansToAttac = 3;
            }
        }
        else
        {
            if (!flag && flag1)
            {

                flag = true;
                flag1 = true;
                distansToAttac = 10;
            }
            else if (!flag1)
            {

                flag = false;
                distansToAttac = 3;
            }
        }

        if ((Vector2.Distance(transform.position, target.position) < distansToAttac))
            IsActive = true;
        else
            IsActive = false;
        if (!target.GetComponent<Pause>().GamePause)
        {
            if (IsActive)
            {
                if (Input.GetKey(KeyCode.Mouse0) && Vector2.Distance(transform.position, target.position) < 2)
                {
                    var directionImpulse = (transform.position - target.position).normalized;
                    rb2d.AddForce(directionImpulse * 20000, ForceMode2D.Impulse);
                    Time = UnityEngine.Time.time;
                }
                else
                {
                    Flip(target);
                    transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * UnityEngine.Time.fixedDeltaTime);
                }
                    
            }
            else if (!IsInPoint)
            {
                Point = Random.Range(0, Points.Length - 1);

                IsInPoint = true;
            }
            else
            {
                if (Vector2.Distance(transform.position, Points[Point].transform.position) > 0.6)
                {
                    Flip(Points[Point].transform);
                    transform.position = Vector2.MoveTowards(transform.position, Points[Point].transform.position, Speed * UnityEngine.Time.fixedDeltaTime);

                }
                    
                else
                    IsInPoint = false;
            }
        }
    }

    private void Flip(Transform target)
    {
        if (isFacingRight && (target.position.x - transform.position.x) < 0f || !isFacingRight && (target.position.x - transform.position.x) > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
