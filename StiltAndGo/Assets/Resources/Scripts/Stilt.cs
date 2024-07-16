using System.Collections;
using System.Collections.Generic;
using ToolBox.Control.Explorer2D;
using ToolBox.Core;
using UnityEngine;

public class Stilt : MonoBehaviour
{
    public enum StiltState
    {
        Ground,
        Air
    }

    private StiltState _state;

    private CharacterController2D _controller;


    public bool highJump;


    // Start is called before the first frame update
    void Start()
    {
        highJump = false;
        _state = StiltState.Air;

        _controller = this.GetComponent<CharacterController2D>();
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

    /*private void FixedUpdate()
    {
        if(_state == StiltState.Ground)
        {
            //_rigidBody.AddForce(Vector3.up * vertSpeed*_multiplier);
            _state=StiltState.Air;
        }
    }*/

    private void _GroundState()
    {
        //if (highJump) _multiplier = 1.5f;
        //else _multiplier = 1;
        //highJump = false;
        _controller.Jump(true);
       // _state = StiltState.Air;
    }

    private void _AirState()
    {
        //_rigidBody.AddForce(direction * horizSpeed);
        _controller.Jump(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Rectangle"))
        {
            _state = StiltState.Ground;
            RectGenerator rectGen=GameObject.FindObjectOfType<RectGenerator>();
            rectGen.AddPoints();
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Rectangle"))
        {
           _state= StiltState.Air;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("LimitLeft"))
        {
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        Destroy(this.gameObject);
        GameController.Instance.Gui.ActivePanel("GameOverPanel");
    }

}
