using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag.Equals("Stilt"))
        {
            Stilt stilt = collision.collider.GetComponent<Stilt>();
            if(stilt!=null)
            {
                stilt.Life--;
                if (stilt.Life == 0)
                    Destroy(stilt.gameObject);
            }
        }
    }
}
