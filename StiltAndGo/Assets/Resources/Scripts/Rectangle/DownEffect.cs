using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownEffect : Effect
{

    public override void ApplyEffect(GameObject game)
    {
        StartCoroutine("Doing", game);
    }

    public IEnumerator Doing(object o)
    {
        GameObject game = (GameObject)o;
        Stilt stilt = game.GetComponent<Stilt>();
        stilt.Effects = effectValue;
        yield return new WaitForSeconds(5);
        print("DOWN FINISHED");
        stilt.Effects = 0;
    }
}
