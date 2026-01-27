using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeNodeInstance
{
    public SkillTreeNodeSO NodeData { get; private set; }
    public bool Unlocked { get; set; }

    public SkillTreeNodeInstance(SkillTreeNodeSO nodeData, bool unlocked)
    {
        NodeData = nodeData;
        Unlocked = unlocked;
    }
}
