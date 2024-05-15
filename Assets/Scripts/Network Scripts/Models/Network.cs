using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
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

    private void Calculate()
    {
        for (int layer = 1; layer < layers.Count; layer++)
        {
            if (layer != layers.Count - 1)
            {
                layers[layer].CalculateOutput(layers[layer + 1], layer + 1);
            }
            else
            {
                layers[layer].CalculateOutput(layers[0],0);
            }
        }
    }

    private void NetworkInit(int[] numberOfNodes)
    {
        layers = new List<Layer>();

        Layer startLayer = new Layer(numberOfNodes[0], numberOfNodes[0]);
        startLayer.SetOutputs(new float[] { 0f, 0f });
        layers.Add(startLayer);

        for (int node = 1; node < numberOfNodes.Length; node++)
        {
            Layer layer = new Layer(numberOfNodes[node], numberOfNodes[node - 1]);
            layers.Add(layer);
        }
        startLayer.GiveOutput(GetLayers()[1]);
        Calculate();
    }

    public void SetStartValue(float[] values)
    {
        GetLayers()[0].SetOutputs(values);
        GetLayers()[0].GiveOutput(GetLayers()[1]);
        Calculate();
    }

    public float[] GetNetworkOutputs()
    {
        return GetLayers()[GetLayers().Count - 1].GetOutputs();
    }

    public float GetMaxNetworkOutput()
    {
        int index = 0;
        float max = 0;
        for(int i = 0; i < GetLayers()[GetLayers().Count - 1].GetOutputs().Length; i++)
        {
            if(max < GetLayers()[GetLayers().Count - 1].GetOutputs()[i])
            {
                max = GetLayers()[GetLayers().Count - 1].GetOutputs()[i];
                index = i;
            }
        }

        return index;
    }

    public List<Layer> GetLayers()
    {
        return layers;
    }


}
