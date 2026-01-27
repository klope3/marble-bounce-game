using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//temp data used for quick prototyping
[CreateAssetMenu(fileName = "TempDataSO", menuName = "Scriptable Objects/TempDataSO")]
public class TempDataSO : ScriptableObject
{
    [field: SerializeField] public int NewMarbleCost;
    [field: SerializeField] public int NewMarbleBaseHealth;
    [field: SerializeField] public int NewMarbleBaseImpact;
    [field: SerializeField] public int MarbleInventoryLimit;
    [field: SerializeField] public int MarbleSkillCost;
}
