using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObjectPool gemPool;

    public void SpawnPickup(Vector3 position)
    {
        //this will need to be more flexible in future
        GameObject go = gemPool.GetPooledObject();
        go.SetActive(true);
        go.transform.position = position;
    }
}
