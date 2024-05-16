using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

[Serializable]
public class Cost
{
    [SerializeField]
    Network network;

    [SerializeField]
    List<Data> data;

    public Cost(Network network, List<Data> data)
    {
        this.network = network;
        this.data = data;
    }

    public float GetError(float value, float expectedValue)
    {
        float error = value - expectedValue;
        return error * error;
    }

    public float GetLoss(float[] expected)
    {
        float[] outputs = network.GetNetworkOutputs();

        float loss = 0;
        for (int i = 0; i < outputs.Length; i++)
        {
            loss += GetError(outputs[i], expected[i]);
        }

        return loss;
    }

    public float GetAvgCost()
    {
        float cost = 0;

        for(int i = 0; i < data.Count;i++)
        {
            cost += GetLoss(data[i].GetExpected());
        }

        return cost / data.Count;
    }
}
