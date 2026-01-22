using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TreeTest : MonoBehaviour
{
    [Button]
    public void Test()
    {
        TreeNode<string> root = new TreeNode<string>("animals");

        TreeNode<string> dog = new TreeNode<string>("dog");
        TreeNode<string> cat = new TreeNode<string>("cat");

        root.AddChild(dog);
        root.AddChild(cat);

        TreeNode<string> husky = new TreeNode<string>("husky");
        TreeNode<string> chihuahua = new TreeNode<string>("chihuahua");

        dog.AddChild(husky);
        dog.AddChild(chihuahua);

        TreeNode<string> tabby = new TreeNode<string>("tabby");
        TreeNode<string> calico = new TreeNode<string>("calico");

        cat.AddChild(tabby);
        cat.AddChild(calico);

        //root.ForAllNodes((node) => { Debug.Log(node.Data); });
        Debug.Log($"husky? {root.Find((node) => node.Data == "husky") != null}");
        Debug.Log($"calico? {root.Find((node) => node.Data == "calico") != null}");
        Debug.Log($"puppy? {root.Find((node) => node.Data == "puppy") != null}");
    }
}
