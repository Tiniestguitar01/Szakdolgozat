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
    private float[] weights;
    [SerializeField]
    [Range(-1f, 1f)]
    private float bias;

    public Node(int inputNumber)
    {
        this.weights = InitWeight(inputNumber);
        this.bias = InitBias();
    }

    public float[] InitWeight(int inputNumber)
    {
        weights = new float[inputNumber];
        for (int i = 0; i < inputNumber; i++)
        {
            weights[i]= Random.Range(-1f, 1f);
        }
        return weights;
    }

    public float InitBias()
    {
        return Random.Range(-1f, 1f);
    }

    public float[] GetWeight()
    {
        return weights;
    }

    public float GetBias()
    {
        return bias;
    }

}
