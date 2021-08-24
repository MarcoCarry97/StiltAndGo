using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Stilt : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [Range(1, 20)]
    public float force;
    
    public bool isCollided;

    public bool Jump { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        isCollided = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(isCollided)
        {
            Vector2 jumpVector = Vector2.up * force * 50;
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

    private void OnDestroy()
    {
        GameState.Instance.ShowGameOver();
        GameState.Instance.GameOver = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject g = collision.gameObject;
        if (g.tag.Equals("LimitLeft") || g.tag.Equals("LimitRight"))
            Destroy(this.gameObject);
    }

}
