using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;

[System.Serializable]
public class Node
{
    [SerializeField]
    [Range(-1f,1f)]
    private float weight;
    [SerializeField]
    [Range(-1f, 1f)]
    private float bias;

    public Node()
    {
        this.weight = InitWeight();
        this.bias = InitBias();
    }

    public float InitWeight()
    {
        return Random.Range(-1f,1f);
    }

    public float InitBias()
    {
        return Random.Range(-1f, 1f);
    }

    public float GetWeight()
    {
        return weight;
    }

    public float GetBias()
    {
        return bias;
    }

}
