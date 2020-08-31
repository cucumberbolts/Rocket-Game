using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public GameObject player;  // Reference to player

    public GameObject parent;  // The parent of the spikes
    public GameObject spike;  // The original spike
    public GameObject[] spikes;  // List of spikes

    // Spike parameters
    public int distance;  // Distance between spikes
    public int maxHeight;
    public int minHeight;
    public float spikeSpeed;
    public float destroyPoint = -10f;

    // How many total spikes
    public uint spikeCount = 5;

    // The right most spike
    private GameObject backSpike;

    // The x position of each spike in the beginning
    private float[] startPositions;

    void Start()
    {
        spikes = new GameObject[spikeCount];
        startPositions = new float[spikeCount];

        // Includes the original spike
        float startX = spike.transform.position.x;
        spikes[0] = spike;
        startPositions[0] = startX;
        startX += distance;

        // Spawns all the others
        for (int i = 0; i < spikeCount - 1; i++)
        {
            // Set position
            Vector3 position = new Vector3(startX, RandomHeight(), 0);
            // Instatiates spike
            GameObject newSpike = Instantiate(spike, position, Quaternion.identity, parent.transform);
            // Adds spike to list
            spikes[i + 1] = newSpike;
            // Remembers position for when restart
            startPositions[i + 1] = startX;
            // Sets position for next spike
            startX += distance;
        }

        backSpike = spikes.Last();
    }

    void Update()
    {
        if (GameStateManager.IsState(GameState.Playing))
        {
            foreach (GameObject spike in spikes)
            {
                if (spike.transform.position.x < destroyPoint)
                {
                    // Loops the spike to the back
                    int height = Random.Range(minHeight, maxHeight);
                    float xPosition = backSpike.transform.position.x + distance;
                    spike.transform.position = new Vector3(xPosition, height, 0);
                    backSpike = spike;
                }

                // Moves the spike
                spike.transform.position += Vector3.left * Time.deltaTime * spikeSpeed;
            }
        }
    }

    public void Restart()
    {
        for (int i = 0; i < spikes.Length; i++)
            spikes[i].transform.position = new Vector3(startPositions[i], RandomHeight(), 0);
    }

    private float RandomHeight()
    {
        return Random.Range(minHeight, maxHeight) + Random.value;
    }
}
