using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static T Pop<T>(this List<T> list)
    {
        T elem = list[0];
        list.RemoveAt(0);
        return elem;
    }

    public static void Push<T>(this List<T> list, T elem)
    {
        list.Add(elem);
    }
}
