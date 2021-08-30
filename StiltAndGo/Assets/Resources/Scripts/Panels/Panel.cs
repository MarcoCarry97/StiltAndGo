using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
   public void Active()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}
