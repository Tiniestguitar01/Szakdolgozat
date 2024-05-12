using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[System.Serializable]
public class Layer
{
    [SerializeField]
    private List<Node> nodes;
    [SerializeField]
    private float[] outputs;
    [SerializeField]
    private float[] inputs;

    public Layer(int numberOfNodes) 
    {
        nodes = new List<Node>();
        for (int i = 0; i < numberOfNodes; i++)
        {
            Node node = new Node();
            nodes.Add(node);
        }
        outputs = new float[numberOfNodes];
    }

    public float[] CalculateOutput()
    {
        for(int i = 0; i < nodes.Count; i++)
        {
            for (int j = 0; j < inputs.Length; j++)
            {
                outputs[i] = ActivationFunction(nodes[i].GetWeight() * inputs[j] + nodes[i].GetBias());
            }
        }

        return outputs;
    }

    public float[] GetInputs()
    {
        return inputs;
    }

    public void SetInputs(float[] inputs)
    {
        this.inputs = inputs;
    }

    public List<Node> GetNodes()
    {
        return nodes;
    }
    public float ActivationFunction(float input)
    {
        return 1 / (1 + Mathf.Exp(-input));
    }

}
