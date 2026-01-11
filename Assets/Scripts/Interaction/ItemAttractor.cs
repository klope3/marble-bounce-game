using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemAttractor : MonoBehaviour
{
    [SerializeField] private float maxAttractForce;
    [SerializeField] private float multiplier;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        PointPickup pickup = other.GetComponent<PointPickup>();
        if (pickup == null || !pickup.CanBePickedUp) return;

        Vector3 vec = transform.position - pickup.transform.position;
        float forceMultiplier = Mathf.Clamp(multiplier / vec.magnitude, 0, 1);
        pickup.GetComponent<Rigidbody>().AddForce(vec.normalized * forceMultiplier * maxAttractForce);
    }
}
