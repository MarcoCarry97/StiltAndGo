using System;
using System.Collections;
using System.Collections.Generic;
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
        GameState.Instance.ShowGamePanel();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.SetActive(!inGame);
    }
}