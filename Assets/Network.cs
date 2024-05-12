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
        startLayer.SetInputs(new float[] { 0f, 0f });
        layers.Add(startLayer);

        for (int i = 1; i < numberOfNodes.Length; i++)
        {
            Layer layer = new Layer(numberOfNodes[i]);
            layer.SetInputs(layers[i - 1].CalculateOutput());
            layers.Add(layer);
        }
    }

    public void ReCalculate()
    {
        layers[0].CalculateOutput();

        for (int i = 1; i < layers.Count; i++)
        {
            layers[i].SetInputs(layers[i - 1].CalculateOutput());
            layers[i].CalculateOutput();
        }
    }

    public List<Layer> GetLayers()
    {
        return layers;
    }


}
