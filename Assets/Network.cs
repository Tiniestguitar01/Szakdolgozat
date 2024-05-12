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
        /*float[] inputs = new float[numberOfNodes[0]];
        for (int i = 0; i < numberOfNodes[0]; i++)
        {
            inputs[i] = Random.Range(-1f,1f);
        }*/

        Layer startLayer = new Layer(numberOfNodes[0]);
        startLayer.SetOutputs(new float[] { 0f, 0f });
        layers.Add(startLayer);

        for (int i = 1; i < numberOfNodes.Length; i++)
        {
            Layer layer = new Layer(numberOfNodes[i]);
            layers.Add(layer);
        }
        Calculate();
    }

    public void Calculate()
    {
        layers[1].CalculateOutput(layers[0]);

        for (int i = 2; i < layers.Count; i++)
        {
            layers[i].CalculateOutput(layers[i - 1]);
        }
    }

    public List<Layer> GetLayers()
    {
        return layers;
    }


}
