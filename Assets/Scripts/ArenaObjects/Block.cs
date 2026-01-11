using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField, Tooltip("If the damage done would be below this amount, nothing happens.")] 
    private int damageThreshold;
    [SerializeField] private RigidbodyExploder shardExploder;
    [field: SerializeField] public int HealthMax { get; private set; }
    public int Health { get; private set; }
    public delegate void DamageEvent(int amount);
    public event DamageEvent OnDamage;

    private void Awake()
    {
        Health = HealthMax;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Marble marble = collision.collider.GetComponent<Marble>();
        if (marble == null) return;

        ContactPoint contact = collision.GetContact(0);
        int damage = CalculateDamageFromMarble(marble, contact);
        if (damage < damageThreshold) return;
        Health -= damage;

        shardExploder.transform.position = contact.point;
        shardExploder.Explode((float)damage / HealthMax);

        OnDamage?.Invoke(damage);
        if (Health <= 0) gameObject.SetActive(false);
    }

    private int CalculateDamageFromMarble(Marble marble, ContactPoint contact)
    {
        Vector3 marbleVelocity = marble.GetComponent<Rigidbody>().velocity;
        float normalSpeed = Mathf.Abs(Vector3.Dot(marbleVelocity, contact.normal));
        int damage = Mathf.RoundToInt(marble.BaseImpactDamage * normalSpeed);
        return damage;
    }
}
