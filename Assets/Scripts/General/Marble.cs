using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Marble : MonoBehaviour
{
    [field: SerializeField] public int BaseImpactStrength { get; private set; }
    [field: SerializeField] public int HealthMax { get; private set; }
    [SerializeField, Tooltip("How long to wait to destroy the object after health hits 0.")] private float destroyDelay;
    [ShowInInspector, DisplayAsString] public int Health { get; private set; }
    private GamePoints gamePoints;
    public delegate void PointsEvent(int points);
    public event PointsEvent OnEarnPoints;
    public delegate void MarbleEvent(Marble marble);
    public event MarbleEvent OnDamage;
    public event MarbleEvent OnDestroy;

    private void Awake()
    {
        gamePoints = FindObjectOfType<GamePoints>();
        Health = HealthMax;
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

    public void ReceiveBlockImpact(Block block)
    {
        Health -= 1;
        OnDamage?.Invoke(this);
        if (Health <= 0)
        {
            StartCoroutine(CO_Destroy());
            OnDestroy?.Invoke(this);
        }
    }

    public void ReceiveFlingerGrab()
    {

    }

    private IEnumerator CO_Destroy()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(transform.parent.gameObject); //the Marble is a physics object inside a parent container
    }
}
