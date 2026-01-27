using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Marble
{
    [ShowInInspector, DisplayAsString] public int BaseHealth { get; private set; }
    [ShowInInspector, DisplayAsString] public int BaseImpactStrength { get; private set; }
    //there will be more data than this to make marbles unique
    private List<SkillTreeNodeSO> ownedSkills;

    public Marble(int baseHealth, int baseImpactStrength)
    {
        BaseHealth = baseHealth;
        BaseImpactStrength = baseImpactStrength;
        ownedSkills = new List<SkillTreeNodeSO>();
    }

    public bool HasSkill(SkillTreeNodeSO node)
    {
        return ownedSkills.Contains(node);
    }

    public void UnlockSkill(SkillTreeNodeSO node)
    {
        ownedSkills.Add(node);
    }
}
