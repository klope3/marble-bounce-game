using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private PickupSpawner pickupSpawner;

    public void RegisterBlockBroken(Block block)
    {
        pickupSpawner.SpawnPickup(block.transform.position);
    }
}
