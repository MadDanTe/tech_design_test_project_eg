using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSortingLayer : MonoBehaviour
{
    [SerializeField] private string sortingLayerName = "Default";
    
    void Start()
    {
        ApplyToAllChildren();
    }

    [ContextMenu("Apply Sorting Settings")]
    public void ApplyToAllChildren()
    {
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>(true);

        foreach (Renderer renderer in childRenderers)
        {
            renderer.sortingLayerName = sortingLayerName;
        }
    }
}
