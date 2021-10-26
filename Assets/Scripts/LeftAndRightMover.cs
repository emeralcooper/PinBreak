using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRightMover : MonoBehaviour
{
    [SerializeField] float myLeftBoundary;
    [SerializeField] float myRightBoundary;
    [SerializeField] float myMoveSpeed = 1.5f;

    float direction = 1;
    float myWidth;

    void Start()
    {
        myWidth = transform.localScale.x;
        myLeftBoundary += myWidth / 2;
        myRightBoundary -= myWidth / 2;
    }


    void Update()
    { 
        transform.Translate(Vector3.right * myMoveSpeed * Time.deltaTime * direction);
        if(transform.position.x < myLeftBoundary)
        {
            direction = 1;           
        }
        else if(transform.position.x > myRightBoundary)
        {
            direction = -1;
        }
    }
}
