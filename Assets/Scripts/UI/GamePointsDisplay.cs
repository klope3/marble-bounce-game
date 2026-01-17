using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePointsDisplay : MonoBehaviour
{
    [SerializeField] private GamePoints points;
    [SerializeField] private TMPro.TextMeshProUGUI point1Text;
    [SerializeField] private TMPro.TextMeshProUGUI point2Text;
    [SerializeField] private TMPro.TextMeshProUGUI statsText;
    [SerializeField] private float pointsRatePollingInterval;
    //private float timer;
    //private int pointsLastPoll;
    //private float highestPointsRate;

    public void Initialize()
    {
        points.OnPointsChange += UpdateMainDisplay;
        UpdateMainDisplay();
    }

    private void Update()
    {
        //timer += Time.deltaTime;
        //if (timer > pointsRatePollingInterval)
        //{
        //    UpdateStatsDisplay();
        //    timer = 0;
        //}
    }

    private void UpdateMainDisplay()
    {
        point1Text.text = $"{points.GetPoints(GamePoints.PointType.One)}";
        point2Text.text = $"{points.GetPoints(GamePoints.PointType.Two)}";
    }

    //private void UpdateStatsDisplay()
    //{
    //    int delta = points.Points - pointsLastPoll;
    //    pointsLastPoll = points.Points;
    //    float changeRate = delta / pointsRatePollingInterval;
    //    if (changeRate > highestPointsRate) highestPointsRate = changeRate;
    //
    //    statsText.text = $"${changeRate}/sec. (${highestPointsRate}/sec. max)";
    //}
}
