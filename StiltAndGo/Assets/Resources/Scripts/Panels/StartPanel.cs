using System;
using System.Collections;
using System.Collections.Generic;
using ToolBox.Control.Explorer2D;
using ToolBox.Core;
using ToolBox.GUI;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : Panel
{
    public Button startButton;

    private bool inGame;


    // Start is called before the first frame update
    void Start()
    {
        startButton = this.transform.GetChild(1).GetComponent<Button>();
        startButton.onClick.AddListener(OnPressed);
        inGame = false;
    }

    private void OnPressed()
    {
        RectGenerator generator = GameObject.FindGameObjectWithTag("Generator")
            .GetComponent<RectGenerator>();
        generator.SetState(RectGenerator.GenState.Play);
        GameController.Instance.Gui.ActivePanel("GamePanel");
        GameController.Instance.Commands.SetState(InputController.State.CharacterControl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}