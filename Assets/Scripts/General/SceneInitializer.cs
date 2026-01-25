using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private MarbleFlinger flinger;
    [SerializeField] private GamePointsDisplay pointsDisplay;
    [SerializeField] private MarbleManager marbleManager;
    [SerializeField] private MarbleInventoryUI inventoryUI;

    private void Awake()
    {
        InputActionsProvider.Initialize();
        flinger.Initialize();
        pointsDisplay.Initialize();
        inventoryUI.Initialize();
        marbleManager.Initialize();
        gameState.Initialize();
    }
}
