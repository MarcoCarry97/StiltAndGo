using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : Panel
{
    private Button startButton;

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
        RectGenerator generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<RectGenerator>();
        InitRectMove init = GameObject.FindGameObjectWithTag("Init").GetComponent<InitRectMove>();
        if(generator!=null && init!=null)
        {
            init.isMoving = generator.isMoving = true;
            inGame = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.SetActive(!inGame);
    }
}
