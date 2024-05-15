using UnityEngine;

public class NetworkPlane : MonoBehaviour
{
    [SerializeField]
    private int[] nodes;

    [SerializeField]
    Network network;

    public GameObject circle;

    SpriteRenderer[,] circles;

    void Start()
    {
        network = new Network(nodes);
        circles = new SpriteRenderer[200, 200];

        for (int x = 0; x < 200; x++)
        {
            for (int y = 0; y < 200; y++)
            {
                GameObject gameObject = Instantiate(circle);
                gameObject.transform.position = new Vector3(x, y, 0);
                circles[x, y] = gameObject.GetComponent<SpriteRenderer>();
            }
        }
    }

    private void Update()
    {
        for (int x = 0; x < 200; x++)
        {
            for (int y = 0; y < 200; y++)
            {
                network.SetStartValue(new float[] { x, y });
                if (network.GetNetworkOutputs()[0] >= network.GetNetworkOutputs()[1])
                {
                    circles[x, y].color = Color.blue;
                }
                else
                {
                    circles[x, y].color = Color.red;
                }
            }
        }
    }
}
