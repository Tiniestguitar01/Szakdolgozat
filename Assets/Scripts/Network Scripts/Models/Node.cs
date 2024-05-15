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
    [Range(-20f, 20f)]
    private float bias;

    public Node(int inputNumber)
    {
        this.weights = InitWeight(inputNumber);
        this.bias = InitBias();
    }

    public float[] InitWeight(int inputNumber)
    {
        weights = new float[inputNumber];
        for (int weight = 0; weight < inputNumber; weight++)
        {
            weights[weight] = Random.Range(-1f, 1f);
        }
        return weights;
    }

    public float InitBias()
    {
        return Random.Range(-20f, 20f);
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
