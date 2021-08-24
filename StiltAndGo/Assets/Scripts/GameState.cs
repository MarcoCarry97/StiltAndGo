using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static GameState instance;

    private PanelController panelController;

    public int Points { get; private set; }

    public bool GameOver { get; set; }
    public static GameState Instance
    {
        get
        {
            if (instance == null)
                instance = new GameObject("GameState").AddComponent<GameState>();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        panelController = PanelController.Instance;
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowStart()
    {
        panelController.ActivePanel("StartPanel");
    }

    public void ShowGameOver()
    {
        panelController.ActivePanel("GameOverPanel");
    }

    public void Reload()
    {
        Points = 0;
        GameOver = false;
        panelController.Clear();
    }

    public void AddPoints(int num)
    {
        if(!GameOver)
            Points += num;
    }
}
