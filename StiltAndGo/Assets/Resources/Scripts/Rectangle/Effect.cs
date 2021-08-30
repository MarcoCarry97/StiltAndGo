using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    [Range(-50, 50)]
    public float effectValue;

    private GameObject stilt;

    public abstract void ApplyEffect(GameObject game);

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.tag.Equals("Stilt"))
        {
            stilt = collision.collider.gameObject;
            ApplyEffect(stilt);
        }
    }

    private void OnDestroy()
    {
        if(stilt!=null)
        {
            stilt.GetComponent<Stilt>().Effects = 0;
        }
    }
}




