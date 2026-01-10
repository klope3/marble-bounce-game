using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyExploder : MonoBehaviour
{
    [SerializeField] private string poolId;
    [SerializeField] private int minCount;
    [SerializeField] private int maxCount;
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;
    [SerializeField] private float minTorque;
    [SerializeField] private float maxTorque;
    [SerializeField] private float initialOffset;
    private GameObjectPool pool;
    public delegate void GenerateEvent(Rigidbody generatedRb);
    public event GenerateEvent OnGenerateRigidbody;

    private void Awake()
    {
        pool = Utils.GetPoolWithId(poolId);
    }

    [Sirenix.OdinInspector.Button]
    public void Explode()
    {
        int count = Random.Range(minCount, maxCount);

        for (int i = 0; i < count; i++)
        {
            GameObject obj = pool.GetPooledObject();
            obj.SetActive(true);
            Vector3 randOffset = Random.insideUnitSphere.normalized * initialOffset;
            Vector3 initialPosition = transform.position + randOffset;
            obj.transform.position = initialPosition;
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb == null) continue;

            float force = Random.Range(minForce, maxForce);
            Vector3 forceVec = initialPosition - transform.position;
            rb.AddForce(forceVec.normalized * force, ForceMode.Impulse);
            rb.AddTorque(new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque)), ForceMode.Impulse);
        }
    }
}
