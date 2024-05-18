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

    private float biasChange;
    private float[] weightChanges;

    public Node(int inputNumber)
    {
        this.weights = InitWeight(inputNumber);
        this.bias = InitBias();
        weightChanges = new float[weights.Length];
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

    public void SetBias(float bias)
    {
        this.bias = bias;
    }

    public void SetBiasChange(float biasChange)
    {
        this.biasChange = biasChange;
    }

    public void SetWeightChange(float weightChange, int index)
    {
        this.weightChanges[index] = weightChange;
    }


    public void ChangeValues(float learnRate)
    {
        bias -= biasChange * learnRate;

        for (int weight = 0; weight < weights.Length; weight++)
        {
            weights[weight] -= weightChanges[weight] * learnRate;
        }
    }
}
