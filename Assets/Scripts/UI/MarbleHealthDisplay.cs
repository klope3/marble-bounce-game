using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarbleHealthDisplay : MonoBehaviour
{
    [SerializeField] private Marble marble;
    [SerializeField] private Image healthBar;

    private void Start()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        healthBar.fillAmount = (float)marble.Health / marble.HealthMax;
    }
}
