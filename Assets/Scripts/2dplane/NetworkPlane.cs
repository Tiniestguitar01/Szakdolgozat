using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class NetworkPlane : MonoBehaviour
{
    [SerializeField]
    private int[] nodes;

    [SerializeField]
    [Range(-2f,2f)]
    private float learnRate;

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
        network = new Network(nodes, learnRate);
        data = new List<Data>();

        //made up data
        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 50; y++)
            {

                if (x < 20 && y < 20)
                {
                    data.Add(new Data(new float[] { x, y }, new float[] { 1, 0 }));
                }
                else
                {
                    data.Add(new Data(new float[] { x, y }, new float[] { 0, 1 }));
                }
            }
        }

        circles = new SpriteRenderer[data.Count];


        for (int i = 0; i < data.Count; i++)
        {
            GameObject gameObject = Instantiate(circle);
            gameObject.transform.position = new Vector3(data[i].GetInputs()[0], data[i].GetInputs()[1], 0);
            circles[i] = gameObject.GetComponent<SpriteRenderer>();
        }

        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].GetExpected()[0] == 1)
            {
                Instantiate(good, new Vector3(data[i].GetInputs()[0], data[i].GetInputs()[1], 0), Quaternion.identity);
            }
        }

        cost = new Cost(network,data);
    }

    public void Save()
    {
        Serialize serialize = new Serialize(network);
        serialize.Save("NetworkTest");
    }

    public void Load()
    {
        Serialize serialize = new Serialize(network);
        network = serialize.Load("NetworkTest");
        cost = new Cost(network, data);
    }

    private void Update()
    {
        float[] allOutput = cost.GetAllOutputIndexes();

        for (int i = 0; i < allOutput.Length; i++)
        {
            if (allOutput[i] == 0)
            {
                circles[i].color = Color.blue;
            }
            else if (allOutput[i] == 1)
            {
                circles[i].color = Color.red;
            }
        }

        costText.text = "Cost: " + cost.GetAvgCost().ToString();
        network.Learn(cost);
    }
}
