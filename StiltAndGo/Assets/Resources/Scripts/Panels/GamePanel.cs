using System.Collections;
using System.Collections.Generic;
using ToolBox.Core;
using ToolBox.GUI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using ToolBox.Control.Explorer2D;

public class GamePanel : Panel
{
    public GameController gameState;

    private Button leftButton;
    private Button rightButton;
    private Button jumpButton;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameController.Instance;
        leftButton = this.transform.GetChild(1).GetComponent<Button>();
        rightButton = this.transform.GetChild(2).GetComponent<Button>();
        jumpButton = this.transform.GetChild(3).GetComponent<Button>();
        
        //leftButton.onClick.AddListener(OnLeft);
        //rightButton.onClick.AddListener(OnRight);
        //jumpButton.onClick.AddListener(OnJump);
    }

    public void OnLeft()
    {
        Stilt stilt=GameObject.FindObjectOfType<Stilt>();
        CharacterController controller = stilt.GetComponent<CharacterController>();
        controller.Move(Vector2.left);
    }

    public void OnRight()
    {
        Stilt stilt = GameObject.FindObjectOfType<Stilt>();
        CharacterController2D controller = stilt.GetComponent<CharacterController2D>();
        controller.Move(Vector2.left);
    }

    public void OnJump()
    {
        Stilt stilt = GameObject.FindObjectOfType<Stilt>();
        CharacterController2D controller = stilt.GetComponent<CharacterController2D>();
        controller.HighJump(jumpButton.IsInvoking());
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < gameState.Life; i++)
        {
            this.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
        }
        for (int i = gameState.Life; i < 3; i++)
        {
            this.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        }*/
    }
}
