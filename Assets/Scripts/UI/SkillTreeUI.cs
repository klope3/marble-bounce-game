using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillTreeUI : MonoBehaviour
{
    [SerializeField] private MarbleManager marbleManager;
    [SerializeField] private GameObject skillTreeParent;
    [SerializeField] private SkillTreeNodeSO rootNodeSO;
    [SerializeField] private SkillTreeNodeUI nodePf;
    [SerializeField] private Transform nodesParent;
    [SerializeField] private Transform linesParent;
    [SerializeField] private UILine uiLine;
    [SerializeField] private float gridSize;
    private int viewedMarbleIndex;

    public void Initialize()
    {
        DrawTree();
        marbleManager.OnMarbleSkillUnlocked += MarbleManager_OnMarbleSkillUnlocked;
    }

    private void MarbleManager_OnMarbleSkillUnlocked(int index)
    {
        DisplaySkillTreeForMarbleIndex(index);
    }

    [Sirenix.OdinInspector.Button]
    private void DrawTree()
    {
        DrawNode(rootNodeSO, null);
    }

    private void DrawNode(SkillTreeNodeSO node, SkillTreeNodeUI parent)
    {
        SkillTreeNodeUI nodeObj = Instantiate(nodePf, nodesParent);
        nodeObj.nodeSO = node;
        nodeObj.parent = parent;
        nodeObj.GetComponent<RectTransform>().anchoredPosition = ScaleGridPosition(node.GridPosition);
        nodeObj.OnClick += NodeObj_OnClick;

        foreach (SkillTreeNodeSO child in node.Children)
        {
            uiLine.Draw(ScaleGridPosition(node.GridPosition), ScaleGridPosition(child.GridPosition), Color.white, linesParent);
            DrawNode(child, nodeObj);
        }
    }

    private void NodeObj_OnClick(SkillTreeNodeUI clickedNode)
    {
        marbleManager.UnlockMarbleSkill(viewedMarbleIndex, clickedNode.nodeSO);
    }

    public void DisplaySkillTreeForMarbleIndex(int index)
    {
        viewedMarbleIndex = index;
        Marble marble = marbleManager.GetMarble(index);
        foreach (Transform t in nodesParent)
        {
            SkillTreeNodeUI nodeUI = t.GetComponent<SkillTreeNodeUI>();
            bool skillOwned = marble.HasSkill(nodeUI.nodeSO);
            if (skillOwned)
            {
                nodeUI.SetState(SkillTreeNodeUI.State.Purchased);
            }
            else
            {
                bool parentSkillOwned = nodeUI.parent != null && marble.HasSkill(nodeUI.parent.nodeSO);
                bool isRootNode = nodeUI.nodeSO == rootNodeSO;
                if (parentSkillOwned || isRootNode) nodeUI.SetState(SkillTreeNodeUI.State.Unlocked);
                else nodeUI.SetState(SkillTreeNodeUI.State.Locked);
            }
        }
        skillTreeParent.SetActive(true);
    }

    private Vector2 ScaleGridPosition(Vector2Int gridPosition)
    {
        return new Vector2(gridPosition.x, gridPosition.y) * gridSize;
    }
}
