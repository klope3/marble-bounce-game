using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScale : MonoBehaviour
{
    [SerializeField] private float scale;

    private void Awake()
    {
        Physics.gravity = Vector3.down * 9.8f * scale;
    }
}
