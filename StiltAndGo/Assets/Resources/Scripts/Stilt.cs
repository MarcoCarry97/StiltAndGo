using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Stilt : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [Range(1, 20)]
    public float force;
    
    public bool isCollided;

    public float Effects;

    public int Life { get; set; }

    public bool Jump { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        isCollided = false;
        Effects = 0;
        Life = 3;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(isCollided)
        {
            Vector2 jumpVector = Vector2.up * ((force * 50)+Effects*7.5f);
            if (Jump) jumpVector *= 1.5f;
            rigidBody.AddForce(jumpVector);
            isCollided = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rigidBody.AddForce(Vector2.up * force*50);
        isCollided = true;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject g = collision.gameObject;
        if (g.tag.Equals("LimitLeft"))
            Destroy(this.gameObject);
        else if (g.tag.Equals("LimitRight"))
            Destroy(this.gameObject);
    }


}
