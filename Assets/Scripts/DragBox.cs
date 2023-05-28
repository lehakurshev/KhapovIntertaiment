using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBox : MonoBehaviour
{
    private Vector3 _dragOffest;
    private float _speedDrag = 15f;
    public GameObject Player;
    public float a;
    public float b;
    void Update()
    {
        if (transform.position.y < Player.transform.position.y)
        {
            transform.position =  new Vector3(transform.position.x,transform.position.y,a);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, b);
        }
    }

        public void OnMouseDown()
    {
        
            _dragOffest = this.transform.position - GetMousePosicion();
    }
    public void OnMouseDrag()
    {
        //this.transform.position = GetMousePosicion() + _dragOffest;
        
            this.transform.position = Vector3.MoveTowards(this.transform.position, GetMousePosicion() + _dragOffest, _speedDrag);
    }
    Vector3 GetMousePosicion()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
