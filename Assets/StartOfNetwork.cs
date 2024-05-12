using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class StartOfNetwork : MonoBehaviour
{
    [SerializeField]
    Network network;

    void Start()
    {
        network = new Network(new int[] { 2, 2, 2 });
    }

    private void Update()
    {
        OnDrawGizmos();
    }


    private void OnDrawGizmos()
    {
       List<Layer> layers =  network.GetLayers(); 

       for(int i = 0; i < layers.Count; i++)
       {
            for(int j = 0; j < layers[i].GetNodes().Count; j++)
            {
                Gizmos.DrawSphere(transform.position + new Vector3(i, j, 0), 0.3f);

                if (i > 0)
                {
                    for (int k = 0; k < layers[i - 1].GetNodes().Count; k++)
                    {
                        Gizmos.DrawLine(new Vector3(i - 1, k, 0), new Vector3(i, j, 0));
                    }
                }
            }

       }


        for (float i = 0; i < 100; i+=1f)
        {
            for (float j = 0; j < 100; j+=1f)
            {
                network.GetLayers()[0].SetOutputs(new float[] { i, j });
                network.Calculate();
                Gizmos.color = Color.white;
                Layer lastLayer = network.GetLayers()[network.GetLayers().Count - 1];
                Layer beforeLastLayer = network.GetLayers()[network.GetLayers().Count - 2];
                if (lastLayer.CalculateOutput(beforeLastLayer)[0] > lastLayer.CalculateOutput(beforeLastLayer)[1])
                {
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.blue;
                }
                Gizmos.DrawSphere(new Vector3(i, j, 0), 0.5f);
            }
        }
    }
}
