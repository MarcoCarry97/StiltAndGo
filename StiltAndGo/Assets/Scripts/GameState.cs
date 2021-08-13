using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private GameState instance;

    public GameState Instance
    {
        get
        {
            if (instance == null)
                instance = new GameObject().AddComponent<GameState>();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
