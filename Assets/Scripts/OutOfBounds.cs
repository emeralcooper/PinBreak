using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutOfBounds : MonoBehaviour
{
    public static event Action OnBallOutOfBounds;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            Destroy(collision.gameObject);
            OnBallOutOfBounds();
        }
    }
}
