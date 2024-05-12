using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network
{
    private List<Layer> layers;

    public Network(int[] numberOfNodes)
    {
        layers = new List<Layer>();
        NetworkInit(numberOfNodes[0]);

        for (int i = 1; i < numberOfNodes.Length; i++)
        {
            Layer layer = new Layer(layers[i - 1].GetInputs(), numberOfNodes[i]);
            layers.Add(layer);
        }
    }

    public void NetworkInit(int numberOfNodes)
    {
        float[] inputs = new float[numberOfNodes];
        for (int i = 0; i < numberOfNodes; i++)
        {
            inputs[i] = Random.Range(-1f,1f);
        }
        Layer layer = new Layer(inputs, numberOfNodes);
        layers.Add(layer);
    }

    public List<Layer> GetLayers()
    {
        return layers;
    }


}
