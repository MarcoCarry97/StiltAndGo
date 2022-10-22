using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameState : MonoBehaviour
{

    enum State
    {
        Start,
        Playing,
        Pause,
        GameOver
    }

    private State state;

    private PanelStack stack;

    public List<Panel> panels;

    private bool showStart;

    public float Points { get; private set; }

    public int Life { get; private set; }



    private static GameState _instance;
    public static GameState Instance { get
        {
            if( _instance == null )
            {
                _instance = GameObject.FindObjectOfType<GameState>().GetComponent<GameState>();
            }
            return _instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        stack = new PanelStack();
        showStart = false;
        DontDestroyOnLoad(Instance);
    }

    private void Update()
    {
        switch(state)
        {
            case State.Start: StartState(); break;
            case State.Playing: PlayingState(); break;
            case State.Pause: PauseState(); break;
            case State.GameOver: GameOverState(); break;
        }
    }

    private void StartState()
    {
        if(!showStart)
        {
            ShowStart();
            showStart = true;
        }
    }

    private void GameOverState()
    {
        throw new NotImplementedException();
    }

    private void PauseState()
    {
        throw new NotImplementedException();
    }

    private void PlayingState()
    {
        GameObject game = GameObject.FindGameObjectWithTag("Stilt");
        if (game == null && state!=State.GameOver)
        {
            state = State.GameOver;
            ShowGameOver();
        }
    }

    public void ActivePanel(string name)
    {
        try
        {
            int index = -1;
            for (int i = 0; i < panels.Count; i++)
                if (panels[i].name.Equals(name))
                    index = i;
            Panel p = GameObject.Instantiate(panels[index], this.transform.parent);
            p.name = panels[index].name;

            p.transform.SetParent(this.transform.parent);
            print(p);
            stack.Push(p);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void DeactivePanel()
    {
        stack.Pop();
    }

    public void Clear()
    {
        stack.Clear();
    }

    public void ShowStart()
    {
        this.ActivePanel("StartPanel");
    }

    public void ShowGameOver()
    {
        this.ActivePanel("GameOverPanel");
    }

    public void ShowGamePanel()
    {
        this.ActivePanel("GamePanel");
    }

    public void Reload()
    {
        Points = 0;
        state = State.Playing;
        this.Clear();
    }

    public void AddPoints(int num)
    {
        if (state!=State.GameOver)
            Points += num;
    }

    public void AddLife(int num)
    {
        if (state != State.GameOver)
            Life = min(Life+num, 3);
    }

    private int min(int a, int b)
    {
        if (a < b) return a;
        else return b;
    }
}
