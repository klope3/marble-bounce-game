using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bouncer : MonoBehaviour
{
    [SerializeField, Tooltip("How far down the bouncer object moves when it 'hides'")] 
    private float hideVerticalDistance;
    [SerializeField] private float hideMoveTime;

    public void SetActiveState(bool b)
    {
        float newY = b ? 0 : -1 * hideVerticalDistance;
        transform.DOMoveY(newY, hideMoveTime);
    }
}
