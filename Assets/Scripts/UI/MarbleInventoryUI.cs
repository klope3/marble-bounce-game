using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleInventoryUI : MonoBehaviour
{
    [SerializeField] private MarbleManager marbleManager;
    [SerializeField] private GameObject marbleSlotPf;
    [SerializeField] private GameObject[] allSlots;
    [SerializeField] private GameObject addButton;

    public void Initialize()
    {
        marbleManager.OnInventoryChange += MarbleManager_OnInventoryChange;
    }

    private void MarbleManager_OnInventoryChange()
    {
        for (int i = 0; i < allSlots.Length; i++)
        {
            bool active = i + 1 <= marbleManager.TotalMarbles;
            allSlots[i].SetActive(active);
        }

        addButton.SetActive(marbleManager.TotalMarbles != marbleManager.MaxMarbles);
    }
}
