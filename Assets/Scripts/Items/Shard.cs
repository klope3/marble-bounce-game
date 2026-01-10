using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    [SerializeField, Tooltip("How long after enabling to wait until this becomes pick-uppable.")] 
    private float pickupDelay;
    [SerializeField, Tooltip("Will deactivate if not picked up for this long.")]
    private float lifespan;
    [SerializeField, Tooltip("How long after being picked up to wait until deactivating the object.")]
    private float afterPickupDelay;
    [field: SerializeField] public int Value { get; private set; }

    private void OnEnable()
    {
        StartCoroutine(CO_Lifespan());
    }

    private IEnumerator CO_Lifespan()
    {
        yield return new WaitForSeconds(lifespan);
        gameObject.SetActive(false);
    }
}
