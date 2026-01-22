using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode<T>
{
    public T Data { get; private set; }
    public List<TreeNode<T>> Children { get; private set; }

    public TreeNode(T data)
    {
        Data = data;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> childNode)
    {
        Children.Add(childNode);
    }

    public void ForAllNodes(System.Action<TreeNode<T>> action)
    {
        action(this);
        foreach (TreeNode<T> child in Children)
        {
            child.ForAllNodes(action);
        }
    }

    public TreeNode<T> Find(System.Func<TreeNode<T>, bool> match)
    {
        if (match(this)) return this;

        foreach (TreeNode<T> child in Children)
        {
            TreeNode<T> result = child.Find(match);
            if (result != null) return result;
        }

        return null;
    }
}
