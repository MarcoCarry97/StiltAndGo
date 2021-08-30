using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : Panel
{
    public Stilt stilt;

    // Start is called before the first frame update
    void Start()
    {
        stilt = GameObject.FindGameObjectWithTag("Stilt").GetComponent<Stilt>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < stilt.Life; i++)
        {
            this.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
        }
        for (int i = stilt.Life; i < 3; i++)
        {
            this.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        }
    }
}
