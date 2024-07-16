using System;
using System.Collections;
using System.Collections.Generic;
using ToolBox.Control.Explorer2D;
using ToolBox.Core;
using ToolBox.GUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartPanel : Panel
{
    public Button startButton;
    public Button quitButton;

    private bool inGame;

    private EventSystem eventSystem;


    // Start is called before the first frame update
    void Start()
    {
        startButton = this.transform.GetChild(1).GetComponent<Button>();
        quitButton = this.transform.GetChild(2).GetComponent<Button>();
        startButton.onClick.AddListener(OnStart);
        quitButton.onClick.AddListener(OnQuit);
        inGame = false;
        eventSystem=GameObject.FindObjectOfType<EventSystem>();
        eventSystem.SetSelectedGameObject(startButton.gameObject);
    }

    private void OnStart()
    {
        RectGenerator generator = GameObject.FindGameObjectWithTag("Generator")
            .GetComponent<RectGenerator>();
        generator.SetState(RectGenerator.GenState.Play);
        GameController.Instance.Gui.ActivePanel("GamePanel");
        GameController.Instance.Commands.SetState(InputController.State.CharacterControl);
    }

    private void OnQuit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}