using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    private Stilt stilt;
    // Start is called before the first frame update
    void Start()
    {
        stilt = GameObject.FindGameObjectWithTag("Stilt").GetComponent<Stilt>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
