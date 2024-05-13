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

    public Layer(int numberOfNodes, int incomingNodes) 
    {
        nodes = new List<Node>();
        for (int i = 0; i < numberOfNodes; i++)
        {
            Node node = new Node(incomingNodes);
            nodes.Add(node);
        }
    }

    public float[] CalculateOutput(Layer layer)
    {
        outputs = new float[nodes.Count];
        for (int i = 0; i < GetNodes().Count; i++)
        {
            float output = GetNodes()[i].GetBias();
            for(int k = 0; k < GetNodes()[i].GetWeight().Length; k++)
            {
                output += (GetNodes()[i].GetWeight()[k] * GetInputs()[k]);
            }
            outputs[i] = ActivationFunction(output);
        }

        GiveOutput(layer);

        return outputs;
    }

    public float[] GetOutputs()
    {
        return outputs;
    }

    public void GiveOutput(Layer layer)
    {
        layer.SetInputs(outputs);
    }


    public void SetOutputs(float[] outputs)
    {
        this.outputs = outputs;
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
