using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] Vector2 force = new Vector2(0,50);
    [SerializeField] bool isLeftFlipper;

    Rigidbody2D myRigidBody;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isLeftFlipper)
        {
            CheckForLeftClick();
        }
        else
        {
            CheckForRightClick();
        }        
    }

    private void CheckForRightClick()
    {
        if (Input.GetMouseButton(1))
        {
            AddForce();
            Debug.Log("rightclick");
        }
    }

    private void CheckForLeftClick()
    {
        if (Input.GetMouseButton(0))
        {
            AddForce();
        }
    }

    private void AddForce()
    {
        myRigidBody.AddForce(force);
    }

}
