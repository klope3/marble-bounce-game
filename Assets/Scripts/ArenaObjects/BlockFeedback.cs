using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFeedback : MonoBehaviour
{
    [SerializeField] private Block block;

    private void Awake()
    {
        block.OnDamage += Block_OnDamage;
    }

    private void Block_OnDamage(int amount)
    {
        throw new System.NotImplementedException();
    }
}
