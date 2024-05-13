using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[System.Serializable]
public class Network
{
    [SerializeField]
    private List<Layer> layers;

    public Network(int[] numberOfNodes)
    {
        NetworkInit(numberOfNodes);
    }

    public void NetworkInit(int[] numberOfNodes)
    {
        layers = new List<Layer>();

        Layer startLayer = new Layer(numberOfNodes[0], numberOfNodes[0]);
        startLayer.SetInputs(new float[] { 0f, 0f });
        layers.Add(startLayer);

        for (int i = 1; i < numberOfNodes.Length; i++)
        {
            Layer layer = new Layer(numberOfNodes[i], numberOfNodes[i - 1]);
            layers.Add(layer);
        }
        Calculate();
    }

    public void Calculate()
    {
        for (int i = 0; i < layers.Count; i++)
        {
            if (i != layers.Count - 1)
            {
                layers[i].CalculateOutput(layers[i + 1]);
            }
            else
            {
                layers[i].CalculateOutput(layers[i]);
            }
        }
    }

    public List<Layer> GetLayers()
    {
        return layers;
    }


}
