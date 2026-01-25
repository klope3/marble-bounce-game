using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MarblePickupGatherer : MonoBehaviour
{
    [SerializeField] private MarbleObject marble;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        PointPickup pickup = other.GetComponent<PointPickup>();
        if (pickup != null && pickup.CanBePickedUp)
        {
            marble.CollectPointPickup(pickup);
            pickup.GetCollected();
        }
    }
}
