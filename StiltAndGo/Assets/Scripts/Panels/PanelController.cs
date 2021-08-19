using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public Dictionary<string,Panel> panels;

    private PanelController instance;

    public PanelController Instance
    {
        get
        { 
            if(instance==null)
            {
                instance = new GameObject().AddComponent<PanelController>();
            }
            return instance;
        } 
    }

    


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void ActivePanel(string name)
    {
        panels[name].Active();
    }

    public void DeactivePanel(string name)
    {
        panels[name].Deactive();
    }

}
