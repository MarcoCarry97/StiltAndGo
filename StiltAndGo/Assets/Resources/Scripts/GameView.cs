using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    private static GameView instance;

    public static GameView Instance
    {
        get
        {
            if(instance==null)
            {
                GameObject game = GameObject.FindGameObjectWithTag("GameView");
                GameObject prefab = Resources.Load<GameObject>("Prefabs/Panels/GameView");
                if (game == null)
                {
                    game = GameObject.Instantiate(prefab);
                    game.name = prefab.name;
                }
                instance = game.GetComponent<GameView>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(Instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
