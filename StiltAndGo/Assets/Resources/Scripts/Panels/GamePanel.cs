using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : Panel
{
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gameState.Life; i++)
        {
            this.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
        }
        for (int i = gameState.Life; i < 3; i++)
        {
            this.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        }
    }
}
