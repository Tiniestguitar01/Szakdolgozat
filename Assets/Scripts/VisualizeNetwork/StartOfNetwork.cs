using System.Collections.Generic;
using UnityEngine;

public class StartOfNetwork : MonoBehaviour
{
    [SerializeField]
    private int[] nodes;

    [SerializeField]
    Network network;

    void Start()
    {
        network = new Network(nodes,0.1f);
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
    }
}
