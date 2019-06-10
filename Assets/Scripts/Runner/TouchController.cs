using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    Vector3 startTouchPosition;
    Vector3 endTouchPosition;
    Vector3 swipeDistance;
    float minDelta;
    public static Vector3 currentDirection;

    void Update()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.touches[0];

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        startTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //        print(startTouchPosition);
        //        print(touch.position);
        //    }
        //}
        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 mouseCurrent = Camera.main(Input.mousePosition);
            //print(string.Format("current mouse position: {0}, world mouse position: {1}", Input.mousePosition, mouseCurrent));
            startTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            DirectionToMove();
        }

        
    }

    private void DirectionToMove()
    {
        Vector3 finalPosition = (Input.mousePosition - startTouchPosition).normalized;
        if (Mathf.Abs(finalPosition.x) >= Mathf.Abs(finalPosition.y))
        {
            currentDirection = new Vector3(finalPosition.x, 0f, 0f).normalized;
        }
        else
            currentDirection = new Vector3(0f, 0f, finalPosition.y).normalized;
    }
}
