using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    [SerializeField]
    float[] inputs;

    [SerializeField]
    float[] expected;


    public Data(float[] inputs, float[] expected)
    {
        this.inputs = inputs;
        this.expected = expected;
    }

    public float[] GetExpected()
    {
        return expected;
    }

    public float[] GetInputs()
    {
        return inputs;
    }
}
