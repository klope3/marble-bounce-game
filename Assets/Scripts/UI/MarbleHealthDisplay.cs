using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarbleHealthDisplay : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private Marble marble;

    public void UpdateDisplay()
    {
        healthBar.fillAmount = (float)marble.Health / marble.HealthMax;
    }

    public void LinkToMarble(Marble marble)
    {
        this.marble = marble;
        UpdateDisplay();
        marble.OnDamage += Marble_OnDamage;
        marble.OnDestroy += Marble_OnDestroy;
    }

    private void Marble_OnDestroy(Marble marble)
    {
        marble.OnDamage -= Marble_OnDamage;
        marble.OnDestroy -= Marble_OnDestroy;
    }

    private void Marble_OnDamage(Marble marble)
    {
        UpdateDisplay();
    }
}
