using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleFlinger : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float force;
    [SerializeField] private float damping;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask marbleLayerMask;
    [SerializeField] private LayerMask aimingPlaneLayerMask;
    public Rigidbody GrabbedRb { get; private set; }
    public Vector3 DragVector { get; private set; }

    public void Initialize()
    {
        InputActionsProvider.OnClickStarted += StartFling;
        InputActionsProvider.OnClickCanceled += StopFling;
    }

    private void Update()
    {
        if (GrabbedRb == null) return;

        Ray ray = cam.ScreenPointToRay(InputActionsProvider.GetMousePosition());
        //check if the ray from the camera would hit an imaginary horizontal plane at the same y-level as the marble
        bool rayHitMarblePlane = IntersectRayWithHorizontalPlane(ray, GrabbedRb.position.y, out Vector3 marblePlaneIntersection);
        if (!rayHitMarblePlane)
        {
            StopFling();
            return;
        }

        DragVector = marblePlaneIntersection - GrabbedRb.position;
        if (DragVector.magnitude > maxDistance)
        {
            StopFling();
            return;
        }

        Vector3 springForce = DragVector * force;
        Vector3 dampingForce = -1 * GrabbedRb.velocity * damping;
        GrabbedRb.AddForce(springForce + dampingForce);
    }

    private void StartFling()
    {
        Ray ray = cam.ScreenPointToRay(InputActionsProvider.GetMousePosition());
        bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, 10000, marbleLayerMask);
        if (!hit) return;

        GrabbedRb = hitInfo.collider.attachedRigidbody;
    }

    public void StopFling()
    {
        GrabbedRb = null;
    }

    private bool IntersectRayWithHorizontalPlane(Ray ray, float planeY, out Vector3 intersection)
    {
        intersection = Vector3.zero;
        float t = (planeY - ray.origin.y) / ray.direction.y;

        // Optional: reject intersections "behind" the ray origin
        if (t < 0f)
            return false;

        intersection = ray.origin + ray.direction * t;
        return true;
    }

}
