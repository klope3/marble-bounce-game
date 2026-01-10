using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
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

        int damage = CalculateDamageFromMarble(marble);
        Health -= damage;

        ContactPoint contact = collision.GetContact(0);
        shardExploder.transform.position = contact.point;
        shardExploder.Explode();

        OnDamage?.Invoke(damage);
        if (Health <= 0) gameObject.SetActive(false);
    }

    private int CalculateDamageFromMarble(Marble marble)
    {
        return 1;
    }
}
