using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockFeedback : MonoBehaviour
{
    [SerializeField] private Block block;
    [SerializeField] private Vector4 maxColor;
    [SerializeField] private float flashDuration;
    [SerializeField] private MeshRenderer meshRenderer;
    private readonly int OVERLAY_ID = Shader.PropertyToID("_ColorOverlay");

    private void Awake()
    {
        block.OnImpact += Block_OnImpact;
    }

    private void Block_OnImpact(int amount)
    {
        float t = (float)amount / block.HealthMax;
        float tRemapped = Mathf.Pow(0.5f, -6 * t + 6);
        Vector4 initialColor = Vector4.Lerp(Vector4.zero, maxColor, tRemapped);
        Debug.Log("Tweening");
        DOTween.To(() => initialColor, (Vector4 colorHDR) => meshRenderer.material.SetColor(OVERLAY_ID, colorHDR), Vector4.zero, flashDuration);
    }
}
