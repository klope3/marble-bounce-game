using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePoints : MonoBehaviour
{
    public int Points { get; private set; } //this eventually will need to be some kind of BigNumber
    public System.Action OnPointsChange;

    [Sirenix.OdinInspector.Button]
    public void Add(int amount)
    {
        Points = Mathf.Clamp(Points + amount, 0, int.MaxValue);
        OnPointsChange?.Invoke();
    }
}
