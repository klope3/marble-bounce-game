using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    [field: SerializeField] public int BaseImpactStrength { get; private set; }
    private GamePoints gamePoints;
    public delegate void PointsEvent(int points);
    public event PointsEvent OnEarnPoints;

    private void Awake()
    {
        gamePoints = FindObjectOfType<GamePoints>();
    }

    public void CollectGem(Gem gem)
    {
        //gamePoints.Add(gem.Points);
        OnEarnPoints?.Invoke(gem.Points);
    }

    public void CollectPointPickup(PointPickup pickup)
    {
        gamePoints.Add(pickup.BaseValue, pickup.PointType);
        OnEarnPoints?.Invoke(pickup.BaseValue);
    }

    public void CollectImpactPoints(Block block)
    {
        int points = 1; //will probably need to be more varied
        gamePoints.Add(points, GamePoints.PointType.One);
        OnEarnPoints?.Invoke(points);
    }

    public void ReceiveFlingerGrab()
    {

    }
}
