using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    private GameState state;
    private GameView view;
    private bool isStarted;

    // Start is called before the first frame update
    void Start()
    {
        view = GameView.Instance;
        
        state.GameOver = false;
        isStarted = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isStarted)
        {
            state = GameState.Instance;
            state.ShowStart();
            isStarted = true;
            print("OK");
        }
    }

}
