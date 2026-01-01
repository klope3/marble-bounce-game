using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField] private MarbleFlinger flinger;

    private void Awake()
    {
        InputActionsProvider.Initialize();
        flinger.Initialize();
    }
}
