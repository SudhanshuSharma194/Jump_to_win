using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipegenerator1 : MonoBehaviour
{
    // No of pipes to spawn at start
    public int PipesToSpawn = 10;
    // Distance between two pipes
    public int PipeDistance = 3;
    // Min and Max position (y) of pipe
    public float MinY;
    public float MaxY;
    // Parent object, (usually a empty object)
    public Transform Pipes;
    // Pipe prefab
    public GameObject Pipe;

    private List<Transform> pipesT = new List<Transform>();
    private Transform cameraT;
    private float distance = 15.0f;

    void Start()
    {
        cameraT = Camera.main.transform;
        for (int i = 0; i < PipesToSpawn; ++i)
        {
            // Creates a new instance of the pipe 
            GameObject pipe = Instantiate(Pipe) as GameObject;
            // Reference to the transform component
            Transform pipeTransform = pipe.transform;
            pipesT.Add(pipeTransform);
            // Below code is same as above, only transform component you can access directly
            // without using GetComponent
            //Transform pipeTransform = pipeTransform.GetComponent<Transform>();

            // Modifying X and Y position of pipe
            pipeTransform.position = new Vector3(pipeTransform.position.x + ((i + 1) * PipeDistance), Random.Range(MinY, MaxY), pipeTransform.position.z);
           // pipeTransform.parent = Pipes;

        }
    }

    private void Update()
    {
        foreach (var pipeT in pipesT)
        {
            if (pipeT.position.x < cameraT.position.x)
            {
                if (cameraT.position.x - pipeT.position.x >= distance)
                {
                    pipeT.position = new Vector3(pipeT.position.x + PipesToSpawn * PipeDistance,
                                Random.Range(MinY, MaxY), pipeT.position.z);
                }
            }

        }
    }
}