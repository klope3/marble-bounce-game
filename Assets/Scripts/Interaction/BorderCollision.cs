using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    [SerializeField] private BorderCollisionHandler collisionManager;

    private void OnCollisionEnter(Collision collision)
    {
        Marble marble = collision.collider.GetComponent<Marble>();
        if (marble == null) return;

        ContactPoint contact = collision.GetContact(0);
        collisionManager.HandleCollision(marble, contact);
    }
}
