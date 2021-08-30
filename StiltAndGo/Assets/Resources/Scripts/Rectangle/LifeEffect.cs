using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEffect : Effect
{
    public override void ApplyEffect(GameObject game)
    {
        Stilt stilt = game.GetComponent<Stilt>();
        if(stilt!=null)
        {
            if (stilt.Life < 3)
                stilt.Life++;
        }
    }
}
