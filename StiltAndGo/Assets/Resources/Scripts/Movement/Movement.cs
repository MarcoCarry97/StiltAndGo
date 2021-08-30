using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicMovement : IMovement
{
    public void Move(GameObject gameObject, Vector3 direction, float intensity)
    {
        gameObject.transform.Translate(direction * intensity*Time.deltaTime);
    }

}

public class PhysicalMovement : IMovement
{
    public void Move(GameObject gameObject, Vector3 direction, float intensity)
    {
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(direction * (intensity/2));
    }

}

public class Movement
{
    public ClassicMovement Classic { get; private set; }
    public PhysicalMovement Physics { get; private set; }

    public Movement()
    {
        Classic = new ClassicMovement();
        Physics = new PhysicalMovement();
    }
}