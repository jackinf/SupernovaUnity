using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameObject"></param>
    public static void Reset(this GameObject gameObject)
    {
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="pointer"></param>
    /// <param name="previous"></param>
    /// <param name="loop"></param>
    /// <returns></returns>
    public static T GetNextElement<T>(this List<T> list, ref int pointer, bool previous = false, bool loop = true) where T : class
    {
        if (list == null)
            return null;

        var listCount = list.Count;

        if (!loop && (pointer >= listCount || pointer < 0))
            return null;

        pointer = previous ? pointer - 1 : pointer + 1;
        pointer = pointer == listCount ? 0 : pointer <= -1 ? listCount - 1 : pointer;

        return list[pointer];
    }
}