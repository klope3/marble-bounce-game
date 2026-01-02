using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceFace : MonoBehaviour
{
    [field: SerializeField] public int Value;
    [SerializeField] private float force;
    private MarbleFlinger flinger;

    private void Awake()
    {
        flinger = FindObjectOfType<MarbleFlinger>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Marble marble = collision.collider.GetComponent<Marble>();
        if (marble == null) return;

        marble.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        marble.CollectBounceFacePoints(this);
        Rigidbody marbleRb = marble.GetComponent<Rigidbody>();
        if (flinger.GrabbedRb == marbleRb) flinger.StopFling();
    }
}
