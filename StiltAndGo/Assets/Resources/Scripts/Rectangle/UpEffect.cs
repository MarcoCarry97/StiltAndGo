using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpEffect : Effect
{
    private GameObject game;

    public override void ApplyEffect(GameObject game)
    {
        this.game = game;
        StartCoroutine("Doing", game);
    }

    public IEnumerator Doing(object o)
    {
        GameObject game = (GameObject)o;
        Stilt stilt = game.GetComponent<Stilt>();
        stilt.Effects = effectValue;
        yield return new WaitForSeconds(5);
        print("UP FINISHED");
        stilt.Effects = 0;
    }

}
