using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeUI : MonoBehaviour
{
    [SerializeField] private SkillTreeNodeSO rootNodeSO;
    [SerializeField] private RectTransform nodePf;
    [SerializeField] private Transform nodesParent;
    [SerializeField] private Transform linesParent;
    [SerializeField] private UILine uiLine;
    [SerializeField] private float gridSize;

    private void Awake()
    {
        DrawTree();
    }

    [Sirenix.OdinInspector.Button]
    private void DrawTree()
    {
        DrawNode(rootNodeSO);
    }

    private void DrawNode(SkillTreeNodeSO node)
    {
        RectTransform obj = Instantiate(nodePf, nodesParent);
        obj.anchoredPosition = ScaleGridPosition(node.GridPosition);

        foreach (SkillTreeNodeSO child in node.Children)
        {
            uiLine.Draw(ScaleGridPosition(node.GridPosition), ScaleGridPosition(child.GridPosition), Color.white, linesParent);
            DrawNode(child);
        }
    }

    private Vector2 ScaleGridPosition(Vector2Int gridPosition)
    {
        return new Vector2(gridPosition.x, gridPosition.y) * gridSize;
    }
}
