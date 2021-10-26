using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    public static event Action OnBlockDestroyed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Ball>() != null)
        {
            Destroy(this.gameObject);
            OnBlockDestroyed();
        }  
    }    
}
