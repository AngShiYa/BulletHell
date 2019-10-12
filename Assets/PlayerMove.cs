using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private bool isMouseDown;
    private Vector2 clickPosition;
    private Vector2 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition = transform.position;
            isMouseDown = true;
        } 
        else if (Input.GetMouseButtonUp(0)) 
        {
            isMouseDown = false;
        }

        if (isMouseDown) {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 offset = position - clickPosition;
            transform.position = currentPosition + offset;
        }
    }
}
