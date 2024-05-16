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

    SpriteRenderer[,] circles;

    public TMP_Text costText;

    void Start()
    {
        network = new Network(nodes);
        data = new List<Data>();

        circles = new SpriteRenderer[50, 50];

        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 50; y++)
            {
                GameObject gameObject = Instantiate(circle);
                gameObject.transform.position = new Vector3(x, y, 0);
                circles[x, y] = gameObject.GetComponent<SpriteRenderer>();
            }
        }


        //made up data
        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 50; y++)
            {
                if(x <= 20 && y <= 20)
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

        cost = new Cost(network,data);
    }

    public void Save()
    {
        Serialize serialize = new Serialize(network);
        serialize.Save("NetworkTest");
    }

    private void Update()
    {

        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 50; y++)
            {
                network.SetStartValue(new float[] { x, y });

                if (network.GetNetworkOutputs()[0] > network.GetNetworkOutputs()[1])
                {
                    circles[x, y].color = Color.blue;
                }
                else
                {
                    circles[x, y].color = Color.red;
                }
            }
        }
        costText.text = "Cost: " + cost.GetAvgCost().ToString();
    }
}
