using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePointsDisplay : MonoBehaviour
{
    [SerializeField] private GamePoints points;
    [SerializeField] private TMPro.TextMeshProUGUI text;

    public void Initialize()
    {
        points.OnPointsChange += UpdateDisplay;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        text.text = $"${points.Points}";
    }
}
