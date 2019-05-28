using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    [Range(0,1)]
    public float fallingSpeedKoef = 0.25f;
    public float speed;
    // The point the cube will rotate around
    // They represent the middle point of each 4 bottom edges of the cube
    Vector3 forwardRotationPoint;
    Vector3 backRotationPoint;
    Vector3 leftRotationPoint;
    Vector3 rightRotationPoint;
    Vector3 currentRotationPoint;

    Vector3 bottomCenterPoint;

    Vector3 rightFace;
    Vector3 leftFace;
    Vector3 forwardFace;
    Vector3 backFace;
    public Vector3 currentFace;

    Bounds bounds;
    bool rolling;
    bool gameOver = false;

    void Start()
    {       
        bounds = GetComponent<MeshRenderer>().bounds;
        // Compute the rotation points
        forwardRotationPoint = new Vector3(0, -bounds.extents.y, bounds.extents.z);
        backRotationPoint = new Vector3(0, -bounds.extents.y, -bounds.extents.z);
        leftRotationPoint = new Vector3(-bounds.extents.x, -bounds.extents.y, 0);
        rightRotationPoint = new Vector3(bounds.extents.x, -bounds.extents.y, 0);

        forwardFace = new Vector3(0f, 0f, bounds.extents.z);
        backFace = new Vector3(0f, 0f, -bounds.extents.z);
        rightFace = new Vector3(bounds.extents.x, 0f, 0f);
        leftFace = new Vector3(-bounds.extents.x, 0f, 0f);

        currentRotationPoint = forwardRotationPoint;
        currentFace = forwardFace;
        bottomCenterPoint = new Vector3(0, -bounds.extents.y, 0);
    }

    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKey("up"))
            {
                currentRotationPoint = forwardRotationPoint;
                currentFace = forwardFace;
            }
            // Rotate around back point when pressing the down button
            else if (Input.GetKey("down"))
            {
                currentRotationPoint = backRotationPoint;
                currentFace = backFace;
            }
            // Rotate around left point when pressing the left button
            else if (Input.GetKey("left"))
            {
                currentRotationPoint = leftRotationPoint;
                currentFace = leftFace;
            }
            // Rotate around right point when pressing the right button
            else if (Input.GetKey("right"))
            {
                currentRotationPoint = rightRotationPoint;
                currentFace = rightFace;
            }
            // Make sure you are not already rolling / moving
            if (rolling )
                return;

            // Rotate around forward point when pressing the up button
            if(!CheckForObstacle())
                StartCoroutine(Roll(currentRotationPoint));
        }
        else
        {
            transform.position += Vector3.down * fallingSpeedKoef; //* speed;
        }
    }

    // Make the cube roll around given rotation point
    private IEnumerator Roll(Vector3 rotationPoint)
    {
        // Compute the real rotation point according to current position
        Vector3 point = transform.position + rotationPoint;
        // Compute an axis to rotate in the correct direction
        Vector3 axis = Vector3.Cross(Vector3.up, rotationPoint).normalized;
        float angle = 90;
        float a = 0;
        // Prevent the user from rolling since we already are
        rolling = true;

        while (angle > 0)
        {
            // Compute the angle and rotate the cube around the point
            a = speed;
            transform.RotateAround(point, axis, a);
            // Keep track of the remaining angle
            angle -= a;
            yield return null;
        }
        // Adjust the rotation to make sure the cube rotates **exactly** 90°
        transform.RotateAround(point, axis, angle);

        // Allow the user to roll in a new direction
        CheckIfGrounded();            
        rolling = false;
    }

    private bool CheckIfGrounded()
    {
        Vector3 currentBottomCenter = transform.position + bottomCenterPoint;
        RaycastHit hit;
        if (Physics.Raycast(currentBottomCenter, Vector3.down, out hit))
        {
            Debug.DrawRay(currentBottomCenter, Vector3.down, Color.red);
            return true;
        }
        gameOver = true;
        GameController.Instance.GameOverEvent?.Invoke();
        return false;
    }

    private bool CheckForObstacle()
    {
        Vector3 face= transform.position + currentFace;
        RaycastHit hit;
        if (Physics.Raycast(face, currentFace.normalized, out hit, 0.1f))
        {
            Debug.DrawRay(face, currentFace.normalized, Color.red);
            gameOver = true;
            GameController.Instance.GameOverEvent.AddListener(GetComponent<PlayerExplosion>().InvokeExplosion);
            GameController.Instance.GameOverEvent?.Invoke();
            GameController.Instance.GameOverEvent = null;
            return true;
        }
        return false;
    }


}