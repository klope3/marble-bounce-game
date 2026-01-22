using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillTreeNodeSO", menuName = "Scriptable Objects/SkillTreeNodeSO")]
public class SkillTreeNodeSO : ScriptableObject
{
    [field: SerializeField] public string SkillName { get; private set; }
    [field: SerializeField] public Vector2Int GridPosition { get; private set; }
    [field: SerializeField] public SkillTreeNodeSO[] Children { get; private set; }
}
