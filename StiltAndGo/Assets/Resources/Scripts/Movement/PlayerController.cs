using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public abstract void Move(GameObject gameObject, Vector3 direction,float intensity);
}

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public IMovement movement;

    public Stilt stilt;

    [Range(1, 50)]
    public float intensity;
    void Start()
    {
        movement = new Movement().Physics;
        stilt = gameObject.GetComponent<Stilt>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            movement.Move(this.gameObject, Vector2.left, intensity);
        if (Input.GetKey(KeyCode.D))
            movement.Move(this.gameObject, Vector2.right, intensity);
        if (Input.GetKey(KeyCode.Space)) stilt.Jump = true;
        else stilt.Jump = false;
    }
}
