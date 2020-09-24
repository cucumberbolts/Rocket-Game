using System.Linq;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public GameObject parent;  // The parent of the spikes
    public GameObject spikePair;  // The original spike
    private GameObject[] spikes;  // List of spikes

    // Spike parameters
    public int distance;  // Distance between spikes
    public int maxHeight;
    public int minHeight;
    public float spikeSpeed;
    public float destroyPoint = -11f;

    public uint spikeCount = 5;  // How many total spikes

    private GameObject backSpike;  // The right most spike

    private float[] startPositions;  // The x position of each spike in the beginning

    void Start()
    {
        spikes = new GameObject[spikeCount];
        startPositions = new float[spikeCount];

        // Includes the original spike
        float startX = spikePair.transform.position.x;
        spikes[0] = spikePair;
        startPositions[0] = startX;
        startX += distance;

        // Spawns all the others
        for (int i = 1; i < spikeCount; i++)
        {
            Vector3 position = new Vector3(startX, RandomHeight(), 0);
            GameObject newSpike = Instantiate(spikePair, position, Quaternion.identity, parent.transform);
            spikes[i] = newSpike;  // Adds spike to list
            startPositions[i] = startX;  // Remembers position for restart
            startX += distance;  // Sets position for next spike
        }

        backSpike = spikes.Last();
    }

    void Update()
    {
        if (GameStateManager.IsState(GameState.Playing))
        {
            foreach (GameObject spike in spikes)
            {
                if (spike.transform.position.x <= destroyPoint)
                {
                    // Loops the spike to the back
                    float xPosition = backSpike.transform.position.x + distance;
                    spike.transform.position = new Vector3(xPosition, RandomHeight(), 0);
                    backSpike = spike;
                }
                else
                {
                    // Moves the spike
                    spike.transform.position += Vector3.left * Time.deltaTime * spikeSpeed;
                }
            }
        }
    }

    public void Restart()
    {
        for (int i = 0; i < spikes.Length; i++)
            spikes[i].transform.position = new Vector3(startPositions[i], RandomHeight(), 0);

        backSpike = spikes.Last();
    }

    private float RandomHeight()
    {
        return Random.Range(minHeight, maxHeight) + Random.value;
    }
}
