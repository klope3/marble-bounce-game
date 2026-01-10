using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointPickup : MonoBehaviour
{
    [field: SerializeField] public GamePoints.PointType PointType { get; private set; }
    [field: SerializeField] public int BaseValue { get; private set; }
    [SerializeField, Tooltip("How long after enabling to wait until this becomes pick-uppable.")]
    private float pickupDelay;
    [SerializeField, Tooltip("Will deactivate if not picked up for this long.")]
    private float lifespan;
    [SerializeField, Tooltip("How long after being picked up to wait until deactivating the object.")]
    private float afterPickupDelay;
    public bool CanBePickedUp { get; private set; }
    public UnityEvent OnPickedUp;
    private float timer;
    private bool timerActive;

    private void OnEnable()
    {
        timer = 0;
        timerActive = true;
    }

    private void OnDisable()
    {
        CanBePickedUp = false;
    }

    private void Update()
    {
        if (!timerActive) return;
        timer += Time.deltaTime;

        if (timer > pickupDelay)
        {
            CanBePickedUp = true;
        }
        if (timer > lifespan)
        {
            gameObject.SetActive(false);
        }
    }

    public void GetCollected()
    {
        timerActive = false;
        CanBePickedUp = false;
        OnPickedUp?.Invoke();
        StartCoroutine(CO_PostPickup());
    }

    private IEnumerator CO_PostPickup()
    {
        yield return new WaitForSeconds(afterPickupDelay);
        gameObject.SetActive(false);
    }
}
