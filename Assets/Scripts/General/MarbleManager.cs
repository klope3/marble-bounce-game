using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MarbleManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject marblePf;
    [SerializeField] private GamePoints gamePoints;
    [SerializeField] private Transform marbleSpawnPoint;
    [SerializeField] private Transform marblesParent;
    [SerializeField] private MarbleHealthDisplay marbleHealthDisplay;
    [SerializeField] private TempDataSO tempData;
    public int MaxMarbles
    {
        get
        {
            return tempData.MarbleInventoryLimit;
        }
    }
    [ShowInInspector, ReadOnly] private List<Marble> marbleInventory;
    private List<MarbleObject> activeMarbles; //the marbles currently active in the arena
    private int curMarbleIndex; //this increments each item a marble is destroyed and we move on to the next one
    public int TotalMarbles
    {
        get
        {
            return marbleInventory.Count;
        }
    }
    public event System.Action OnInventoryChange;

    public void Initialize()
    {
        marbleInventory = new List<Marble>();
        Marble testMarble = new Marble(tempData.NewMarbleBaseHealth, tempData.NewMarbleBaseImpact);
        AddMarbleToInventory(testMarble, 0);
        activeMarbles = new List<MarbleObject>();
    }

    public void PrepareForRound()
    {
        curMarbleIndex = 0;
    }

    public void SpawnMarble()
    {
        GameObject marbleObj = Instantiate(marblePf, marblesParent);
        marbleObj.transform.position = marbleSpawnPoint.position;
        MarbleObject marble = marbleObj.GetComponentInChildren<MarbleObject>();
        if (marble == null) Debug.LogError("No Marble component found");

        activeMarbles.Add(marble);
        marble.SetMarbleData(marbleInventory[curMarbleIndex]);
        marbleHealthDisplay.LinkToMarble(marble);
        marble.OnDestroy += Marble_OnDestroy;
    }

    public void AddMarbleToInventory(Marble marble, int cost)
    {
        if (TotalMarbles == MaxMarbles || gamePoints.GetPoints(GamePoints.PointType.One) < cost) return;
        marbleInventory.Add(marble);
        gamePoints.Add(-1 * cost, GamePoints.PointType.One);
        OnInventoryChange?.Invoke();
    }

    //later will be replaced by player choosing a specific marble to add
    public void TempAddMarble()
    {
        AddMarbleToInventory(new Marble(tempData.NewMarbleBaseHealth, tempData.NewMarbleBaseImpact), tempData.NewMarbleCost);
    }

    private void Marble_OnDestroy(MarbleObject marble)
    {
        marble.OnDestroy -= Marble_OnDestroy;
        activeMarbles.Remove(marble);
        curMarbleIndex++;

        if (curMarbleIndex == TotalMarbles) gameState.SetState(GameState.State.Upgrade);
        else StartCoroutine(CO_SpawnNext());
    }

    private IEnumerator CO_SpawnNext()
    {
        yield return new WaitForSeconds(1);
        SpawnMarble();
    }
}
