using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField] private MarbleFlinger flinger;
    [SerializeField] private GamePointsDisplay pointsDisplay;

    private void Awake()
    {
        InputActionsProvider.Initialize();
        flinger.Initialize();
        pointsDisplay.Initialize();
    }
}
