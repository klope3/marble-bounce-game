using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public static class Utils
{
    /// <summary>
    /// Picks X number of items randomly from the given colleciton. Uses LINQ and is not very performant for large collections.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="countToChoose"></param>
    /// <returns></returns>
    public static T[] ChooseRandomFromCollection<T>(IEnumerable<T> collection, int countToChoose)
    {
        return collection
            .OrderBy(_ => Guid.NewGuid())
            .Take(countToChoose)
            .ToArray();
    }

    public static int[] GetConsecutiveInts(int start, int count)
    {
        return Enumerable.Range(start, count).ToArray();
    }

    public static GameObjectPool GetPoolWithId(string id)
    {
        GameObjectPool[] pools = GameObject.FindObjectsOfType<GameObjectPool>();
        foreach (GameObjectPool p in pools)
        {
            if (p.Id == id) return p;
        }
        Debug.LogError($"GameObjectPool with id {id} not found.");
        return null;
    }
}
