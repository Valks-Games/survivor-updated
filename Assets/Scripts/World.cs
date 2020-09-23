using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public static string stringSeed = "";
    public static int seed;
    public static float freqX = 0.15f;
    public static float freqZ = 0.15f;
    public static float amplitude = 2f;

    public int seedPreview;
    public static bool randomizeSeed = true;

    //private int worldSize = 10000;

    public void Awake() 
    {
        // Limit framerate to 60
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        if (stringSeed != "" || stringSeed != null)
            // Hash too long and will not work if not divided by at least 100.
            seed = Mathf.Abs(stringSeed.GetHashCode() / 100000);

        if (randomizeSeed) 
            seed = Random.Range(0, 99999);

        Random.InitState(seed);
        seedPreview = seed;
    }

    public void Start()
    {
        GenerateSpawn(1);
    }

    public void Update()
    {
        
    }

    public void GenerateSpawn(int size)
    {
        for (int x = -size; x < size; x++)
        {
            for (int z = -size; z < size; z++)
            {
                GameObject goChunk = new GameObject("Chunk " + x + " " + z);
                WorldChunk worldChunk = goChunk.AddComponent<WorldChunk>();
                worldChunk.Generate(x, z);
            }
        }
    }
}
