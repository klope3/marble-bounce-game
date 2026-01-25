using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Marble
{
    [ShowInInspector, DisplayAsString] public int BaseHealth { get; private set; }
    [ShowInInspector, DisplayAsString] public int BaseImpactStrength { get; private set; }
    //there will be more data than this to make marbles unique

    public Marble(int baseHealth, int baseImpactStrength)
    {
        BaseHealth = baseHealth;
        BaseImpactStrength = baseImpactStrength;
    }
}
