using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleFlingerVisual : MonoBehaviour
{
    [SerializeField] private MarbleFlinger flinger;
    [SerializeField] private LineRenderer line;

    private void Update()
    {
        bool flinging = flinger.GrabbedRb != null;
        line.enabled = flinging;
        if (!flinging) return;

        line.SetPosition(0, flinger.GrabbedRb.position);
        line.SetPosition(1, flinger.GrabbedRb.position + flinger.DragVector);
    }
}
