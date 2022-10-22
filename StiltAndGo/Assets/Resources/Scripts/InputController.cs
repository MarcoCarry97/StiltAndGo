using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    enum InputState
    {
        Gameplay,
        Dialog,
        Pause
    }

    private InputState _state;
    private Stilt _stilt;

    public KeyCode Left, Right;
    public KeyCode Jump;
    public KeyCode Pause;

    // Start is called before the first frame update
    void Start()
    {
        _stilt = this.GetComponent<Stilt>();
        _state = InputState.Gameplay;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_state)
        {
            case InputState.Gameplay: _GameplayState(); break;
            case InputState.Dialog: _DialogState(); break;
            case InputState.Pause: _PauseState(); break;
        }
    }

    private void _PauseState()
    {
        throw new NotImplementedException();
    }

    private void _DialogState()
    {
        throw new NotImplementedException();
    }

    private void _GameplayState()
    {
        Vector3 direction = Vector3.zero;
        bool highJump = false;
        if (Input.GetKey(Left))
            direction.x += -1;
        if (Input.GetKey(Right))
            direction.x += 1;
        if (Input.GetKey(Jump))
            highJump = true;
        if (Input.GetKeyDown(Pause)) { }
        //Active Pause Menu
        _stilt.direction = direction;
        _stilt.highJump = highJump;
    }
}
