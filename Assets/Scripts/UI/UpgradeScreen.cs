using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private GameObject upgradeScreen;

    public void SetVisible(bool b)
    {
        upgradeScreen.SetActive(b);
    }
}
