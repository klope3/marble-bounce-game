using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The border of the level is composed of adjacent blocks, but Unity physics doesn't do well with that setup.
//Instead, larger colliders are used and then the collision points are used to determine which block should have been hit.
public class BorderCollisionHandler : MonoBehaviour
{
    [SerializeField] private Transform leftBorderBlocksParent;
    [SerializeField] private Transform rightBorderBlocksParent;
    [SerializeField] private Transform topBorderBlocksParent;
    [SerializeField] private Transform bottomBorderBlocksParent;

    public void HandleCollision(MarbleObject marble, ContactPoint contact)
    {
        bool bottomBlock = contact.normal == Vector3.forward * -1;
        bool topBlock = contact.normal == Vector3.forward;
        bool leftBlock = contact.normal == Vector3.right * -1;

        Block block;

        if (bottomBlock) block = FindClosestBlock(bottomBorderBlocksParent, contact.point);
        else if (topBlock) block = FindClosestBlock(topBorderBlocksParent, contact.point);
        else if (leftBlock) block = FindClosestBlock(leftBorderBlocksParent, contact.point);
        else block = FindClosestBlock(rightBorderBlocksParent, contact.point);

        block.HandleCollision(marble, contact);
    }

    private Block FindClosestBlock(Transform parent, Vector3 position)
    {
        float smallestDist = float.MaxValue;
        Transform closestTrans = parent.GetChild(0);

        foreach (Transform t in parent)
        {
            float dist = Vector3.Distance(t.position, position);
            if (dist < smallestDist)
            {
                smallestDist = dist;
                closestTrans = t;
            }
        }

        return closestTrans.GetComponent<Block>();
    }
}
