using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Stilt : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [Range(1, 10)]
    public float force;

    
    public bool isCollided;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        isCollided = false;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidBody.AddForce(Vector2.up * force*50);
        
    }

    
}
