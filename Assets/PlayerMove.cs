using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private static List<PlayerMove> movableObjects = new ();
    public float speed = 5f;
    private Vector2 target;
    private bool selected;
    

    // Start is called before the first frame update
    void Start()
    {
        movableObjects.Add(this);
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selected)
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        foreach (var obj in movableObjects)
        {
            if (obj == this)
            {
                obj.selected = true;
                obj.GetComponent<SpriteRenderer>().color = Color.red;    
            }
            else
            {
                obj.selected = false;
                obj.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
