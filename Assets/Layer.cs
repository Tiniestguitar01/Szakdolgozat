using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Layer
{
    private List<Node> nodes;
    private float[] outputs;
    private float[] inputs;

    public Layer(float[] inputs, int numberOfNodes) 
    {
        this.inputs = inputs;
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
                outputs[i] = nodes[i].ActivationFunction(nodes[i].GetWeight() * inputs[j] + nodes[i].GetBias());
            }
        }

        return outputs;
    }

    public float[] GetInputs()
    {
        return inputs;
    }

    public List<Node> GetNodes()
    {
        return nodes;
    }

}
