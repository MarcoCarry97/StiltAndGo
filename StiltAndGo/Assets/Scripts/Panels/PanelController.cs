using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public List<Panel> panels;

    private PanelStack stack;

    private static PanelController instance;

    private Canvas canvas;
    public static PanelController Instance
    {
        get
        { 
            if(instance==null)
            {
                instance = new GameObject("PanelController").AddComponent<PanelController>();
            }
            return instance;
        } 
    }

    


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.transform.parent);
        stack = new PanelStack();
        canvas = this.transform.parent.GetComponent<Canvas>();
    }

    public void ActivePanel(string name)
    {
        int index = -1;
        for(int i=0;i<panels.Count;i++)
            if (panels[i].name.Equals(name))
                index = i;
        Panel p = GameObject.Instantiate(panels[index],this.transform.parent);
        p.name = panels[index].name;
        
        p.transform.SetParent(this.transform.parent);
        
        stack.Push(p);
    }

    public void DeactivePanel()
    {
        stack.Pop();
    }

    public void Clear()
    {
        stack.Clear();
    }

}
