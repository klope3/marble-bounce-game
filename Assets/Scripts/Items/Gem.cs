using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Gem : MonoBehaviour
{
    [field: SerializeField] public int Points { get; private set; }

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Marble marble = other.GetComponent<Marble>();
        Debug.Log(marble);
        if (marble == null) return;

        marble.CollectGem(this);
        gameObject.SetActive(false);
    }
}
