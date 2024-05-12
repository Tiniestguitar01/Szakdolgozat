using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;

public class Node
{
    private float weight;
    private float bias;
    private float output;

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

    public float ActivationFunction(float input)
    {
        output = 1 / (1+ Mathf.Exp(-input));
        return output;
    }

}
