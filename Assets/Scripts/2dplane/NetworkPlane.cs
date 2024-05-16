using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class NetworkPlane : MonoBehaviour
{
    [SerializeField]
    private int[] nodes;

    [SerializeField]
    Network network;
    Cost cost;

    [SerializeField]
    List<Data> data;

    public GameObject circle;
    public GameObject good;

    SpriteRenderer[] circles;

    public TMP_Text costText;

    void Start()
    {
        network = new Network(nodes);
        data = new List<Data>();

        //made up data
        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 50; y++)
            {
                if (x <= 20 && y <= 20)
                {
                    data.Add(new Data(x, y, new float[] { 1, 0 }));
                    //Instantiate(good,new Vector3(x,y,0),Quaternion.identity);
                }
                else
                {
                    data.Add(new Data(x, y, new float[] { 0, 1 }));
                }
            }
        }

        circles = new SpriteRenderer[data.Count];


        for (int i = 0; i < data.Count; i++)
        {
            GameObject gameObject = Instantiate(circle);
            gameObject.transform.position = new Vector3(data[i].GetX(), data[i].GetY(), 0);
            circles[i] = gameObject.GetComponent<SpriteRenderer>();
        }

        cost = new Cost(network,data);
    }

    public void Save()
    {
        Serialize serialize = new Serialize(network);
        serialize.Save("NetworkTest");
    }

    private void Update()
    {
        for (int i = 0; i < data.Count; i++)
        {
            network.SetStartValue(new float[] { data[i].GetX(), data[i].GetY() });
            if (network.GetNetworkOutputs()[0] > network.GetNetworkOutputs()[1])
            {
                circles[i].color = Color.blue;
            }
            else
            {
                circles[i].color = Color.red;
            }
        }

        costText.text = "Cost: " + cost.GetAvgCost().ToString();
    }
}
