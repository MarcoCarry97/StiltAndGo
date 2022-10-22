using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stilt : MonoBehaviour
{
    public enum StiltState
    {
        Ground,
        Air
    }

    private StiltState _state;
    private Rigidbody2D _rigidBody;
    private InputController _controller;

    public Vector3 direction;
    public bool highJump;

    [Range(1, 1000)]
    public float vertSpeed;

    [Range(1, 1000)]
    public float acceleration;

    [Range(1, 1000)]
    public float horizSpeed;

    private float _multiplier;

    private float _velocity;
    private Vector2 _currentVelocity;
    private float _distance;

    // Start is called before the first frame update
    void Start()
    {
        highJump = false;
        _state = StiltState.Air;
        _rigidBody=this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        print(_state);
        switch(_state)
        {
            case StiltState.Ground: _GroundState(); break;
            case StiltState.Air: _AirState(); break;
        }
    }

    private void FixedUpdate()
    {
        if(_state == StiltState.Ground)
        {
            _rigidBody.AddForce(Vector3.up * vertSpeed*_multiplier);
            _state=StiltState.Air;
        }
    }

    private void _GroundState()
    {
        if (highJump) _multiplier = 1.5f;
        else _multiplier = 1;
        //highJump = false;
    }

    private void _AirState()
    {
        print(_multiplier);
        _rigidBody.AddForce(direction * horizSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Rectangle"))
        {
            _state = StiltState.Ground;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Rectangle"))
        {
           _state= StiltState.Air;
        }
    }
}
