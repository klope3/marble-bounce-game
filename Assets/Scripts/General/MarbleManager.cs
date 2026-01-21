using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject marblePf;
    [SerializeField] private Transform marbleSpawnPoint;
    [SerializeField] private Transform marblesParent;
    [SerializeField] private MarbleHealthDisplay marbleHealthDisplay;
    private int activeMarbles;

    public void SpawnMarble()
    {
        GameObject marbleObj = Instantiate(marblePf, marblesParent);
        activeMarbles++;
        marbleObj.transform.position = marbleSpawnPoint.position;
        Marble marble = marbleObj.GetComponentInChildren<Marble>();
        if (marble == null) Debug.LogError("No Marble component found");

        marbleHealthDisplay.LinkToMarble(marble);
        marble.OnDestroy += Marble_OnDestroy;
    }

    private void Marble_OnDestroy(Marble marble)
    {
        marble.OnDestroy -= Marble_OnDestroy;
        activeMarbles--;
        if (activeMarbles == 0) gameState.SetState(GameState.State.Upgrade);
    }
}
