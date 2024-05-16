using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    float x;
    float y;

    [SerializeField]
    float[] expected;


    public Data(float x, float y, float[] expected)
    {
        this.x = x;
        this.y = y;
        this.expected = expected;
    }

    public float GetX()
    {
        return x;
    }

    public float GetY()
    {
        return y;
    }

    public float[] GetExpected()
    {
        return expected;
    }
}
