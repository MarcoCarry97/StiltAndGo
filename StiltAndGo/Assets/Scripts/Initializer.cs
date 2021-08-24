using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    private GameState state;
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
        state.ShowStart();
        Destroy(this.gameObject);
    }
}
