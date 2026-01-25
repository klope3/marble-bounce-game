using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePoints : MonoBehaviour
{
    private Dictionary<PointType, int> pointsDictionary;
    //YOU FORGOT EVENT AGAIN vvvvvvv
    public System.Action OnPointsChange;

    public enum PointType
    {
        One,
        Two,
        Three
    }

    private void InitializeDict()
    {
        pointsDictionary = new Dictionary<PointType, int>
        {
            { PointType.One, 0 },
            { PointType.Two, 0 },
            { PointType.Three, 0 },
        };
    }

    [Sirenix.OdinInspector.Button]
    public void Add(int amount, PointType type)
    {
        pointsDictionary[type] = Mathf.Clamp(pointsDictionary[type] + amount, 0, int.MaxValue);
        OnPointsChange?.Invoke();
    }

    public int GetPoints(PointType type)
    {
        if (pointsDictionary == null) InitializeDict();
        return pointsDictionary[type];
    }
}
