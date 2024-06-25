using System.Collections;
using System.Collections.Generic;
using ToolBox.Core;
using ToolBox.GUI;
using UnityEngine;

public class GamePanel : Panel
{
    public GameController gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameController.Instance;
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
