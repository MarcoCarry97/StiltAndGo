using System;
using System.Collections;
using System.Collections.Generic;
using ToolBox.Control.Explorer2D;
using ToolBox.GUI;
using ToolBox.Interaction;
using UnityEngine;
using ToolBox.Core;
using ToolBox.GUI.Utils;
using ToolBox.Animations;

namespace ToolBox.Control.Explorer2D
{
    public class InputController : MonoBehaviour
    {
        public enum State
        {
            CharacterControl,
            PauseControl,
            DialogControl,
            VictoryControl
        }

        private State state;

        private Vector3 direction;


        public Vector3 Direction { get; private set; }

        public bool HighJump {  get; private set; }

        private bool isButtonControlled;

        private void Awake()
        {
            Start();
        }

        // Start is called before the first frame update
        void Start()
        {
            state = State.DialogControl;
            isButtonControlled = false;
        }

        // Update is called once per frame
        void Update()
        {
            switch (state)
            {
                case State.CharacterControl:
                    CharacterControlState();
                    break;
                case State.DialogControl:
                    DialogControlState();
                    break;
                case State.PauseControl:
                    PauseControlState();
                    break;

            }
        }

        private void CharacterControlState()
        {
            if (Input.GetButtonDown("Pause"))
            {
                SetState(State.PauseControl);
                GameController.Instance.Gui.ActivePanel("PausePanel");
            }
            direction = Vector3.zero;
            float horiz = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");
            direction.x = horiz;
            //direction.y = vert;
            direction = direction.normalized;
            GameObject game = GameObject.FindGameObjectWithTag("MainCharacter");
            if (game != null)
            {
                print(direction + " " + HighJump);
                CharacterController2D control = game.GetComponent<CharacterController2D>();
                control.Move(direction);
                control.HighJump(Input.GetButton("Jump"));
                //game.GetComponent<AnimatorController>().SetDirection(direction);
                Direction = direction;
            }
        }

        public void DialogControlState()
        {
            isButtonControlled = Input.anyKey && !Input.GetMouseButtonDown(0);
            if (Input.anyKey && !isButtonControlled)
            {
                //GameController.Instance.Gui.UseButtons();
            }
        }

        public void PauseControlState()
        {
            if (Input.GetButtonDown("Pause"))
            {
                GameController.Instance.Gui.DeactivePanel();
                state = State.CharacterControl;
            }

        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public void Clear()
        {
            Start();
        }
    }
}