using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.isKinematic = true;
    }

    public void SetRigidBodyToDynamic()
    {
        myRigidbody2D.isKinematic = false;
    }

    public void SetRigidBodyToKynematic()
    {
        myRigidbody2D.isKinematic = true;
    }

}
