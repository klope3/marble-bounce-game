using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class MarbleFloatingPointsText : MonoBehaviour
{
    [SerializeField] private MarbleObject marble;
    [SerializeField] private MMF_Player floatingTextPlayer;

    private void Awake()
    {
        marble.OnEarnPoints += Marble_OnEarnPoints;
    }

    private void Marble_OnEarnPoints(int points)
    {
        MMF_FloatingText floatingText = floatingTextPlayer.GetFeedbackOfType<MMF_FloatingText>();
        floatingText.Value = $"+{points}";
        floatingTextPlayer.PlayFeedbacks();
    }
}
