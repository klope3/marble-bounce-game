using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField, Tooltip("If the impact strength would be below this amount, nothing happens.")] 
    private int impactThreshold;
    [SerializeField] private RigidbodyExploder shardExploder;
    [field: SerializeField] public int HealthMax { get; private set; }
    [SerializeField] private bool impactCausesDamage;
    [SerializeField] private bool impactEarnsPoints;
    public int Health { get; private set; }
    private BlockManager blockManager;
    private GamePoints gamePoints;
    public delegate void IntEvent(int amount);
    public event IntEvent OnImpact;
    public event IntEvent OnDamage;
    public event IntEvent OnEarnPoints;

    private void Awake()
    {
        Health = HealthMax;
        gamePoints = FindObjectOfType<GamePoints>();
        blockManager = FindObjectOfType<BlockManager>();
    }

    public void HandleCollision(MarbleObject marble, ContactPoint contact)
    {
        int impact = CalculateImpactFromMarble(marble, contact);
        if (impact < impactThreshold) return;

        if (impactCausesDamage)
        {
            int damage = impact; //may or may not end up being equal to impact
            Health -= damage;
            OnDamage?.Invoke(damage);
        }
        if (impactEarnsPoints)
        {
            marble.CollectImpactPoints(this);
        }

        //shardExploder.transform.position = contact.point;
        //shardExploder.Explode((float)impact / HealthMax);

        marble.ReceiveBlockImpact(this);
        OnImpact?.Invoke(impact);
        if (Health <= 0)
        {
            gameObject.SetActive(false);
            blockManager.RegisterBlockBroken(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        MarbleObject marble = collision.collider.GetComponent<MarbleObject>();
        if (marble == null) return;

        ContactPoint contact = collision.GetContact(0);
        HandleCollision(marble, contact);
    }

    private int CalculateImpactFromMarble(MarbleObject marble, ContactPoint contact)
    {
        Vector3 marbleVelocity = marble.GetComponent<Rigidbody>().velocity;
        float normalSpeed = Mathf.Abs(Vector3.Dot(marbleVelocity, contact.normal));
        int damage = Mathf.RoundToInt(marble.ImpactStrength * normalSpeed);
        return damage;
    }
}
