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

    public float[] CalculateOutput(Layer layer)
    {
        outputs = new float[nodes.Count];
        for (int i = 0; i < nodes.Count; i++)
        {
            float output = 0;
            for (int j = 0; j < layer.GetOutputs().Length; j++)
            {
                output += (layer.nodes[j].GetWeight() * layer.GetOutputs()[j]) + nodes[i].GetBias();
            }
            outputs[i] = ActivationFunction(output);
        }

        return outputs;
    }

    public float[] GetOutputs()
    {
        return outputs;
    }


    public void SetOutputs(float[] outputs)
    {
        this.outputs = outputs;
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
