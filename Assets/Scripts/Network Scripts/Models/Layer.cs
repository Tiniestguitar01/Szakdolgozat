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
        outputs = new float[nodes.Count];
    }

    public float[] CalculateOutput(Layer layer,int layerNumber)
    {
        outputs = new float[nodes.Count];
        for (int node = 0; node < GetNodes().Count; node++)
        {
            float output = GetNodes()[node].GetBias();
            for(int weight = 0; weight < GetNodes()[node].GetWeight().Length; weight++)
            {
                output += (GetNodes()[node].GetWeight()[weight] * GetInputs()[weight]);
            }
            //if(layerNumber != 0)
            {
                outputs[node] = ActivationFunction(output);
            }
            //else
            //{
            //    outputs[node] = output;
            //}
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
        //return input > 0 ? input : 0;
        // return 1 / (1 + Mathf.Exp(-input));
        return input / (1 + Mathf.Exp(-input));
    }

}
