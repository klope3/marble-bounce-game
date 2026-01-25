using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarbleHealthDisplay : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private MarbleObject marble;

    public void UpdateDisplay()
    {
        healthBar.fillAmount = (float)marble.Health / marble.HealthMax;
    }

    public void LinkToMarble(MarbleObject marble)
    {
        this.marble = marble;
        UpdateDisplay();
        marble.OnDamage += Marble_OnDamage;
        marble.OnDestroy += Marble_OnDestroy;
    }

    private void Marble_OnDestroy(MarbleObject marble)
    {
        marble.OnDamage -= Marble_OnDamage;
        marble.OnDestroy -= Marble_OnDestroy;
    }

    private void Marble_OnDamage(MarbleObject marble)
    {
        UpdateDisplay();
    }
}
