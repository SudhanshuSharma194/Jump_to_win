using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclegen : MonoBehaviour
{
    // No of obstacles to spawn at start
    public int ObstaclesToSpawn = 10;
    // Distance between two obstacles
    public int ObstacleDistance = 3;
    // Min and Max position (y) of obstacle
    public float MinY;
    public float MaxY;
    // Parent object, (usually a empty object)
    public Transform Obstacles;
    // Obstacle prefab
    public GameObject Obstacle;

    private List<Transform> obstaclesT = new List<Transform>();
    //private List<Transform> obstaclesT1 = new List<Transform>();
    private Transform cameraT;
    private float distance = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        if(mainmenu.level=="Level II")
        {
            ObstaclesToSpawn++;
            ObstacleDistance -= 5;
        }
        cameraT = Camera.main.transform;
        for (int i = 0; i < ObstaclesToSpawn; ++i)
        {
            // Creates a new instance of the obstacle 
            GameObject obstacle = Instantiate(Obstacle) as GameObject;
            // Reference to the transform component
            Transform obstacleTransform = obstacle.transform;
            obstaclesT.Add(obstacleTransform);

            // Modifying X and Y position of obstacle
            obstacleTransform.position = new Vector3(obstacleTransform.position.x + ((i + 1) * ObstacleDistance), Random.Range(MinY, MaxY), obstacleTransform.position.z);
            // obstacleTransform.parent = Obstacles;

        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var obstacleT in obstaclesT)
        {
            if (obstacleT.position.x < cameraT.position.x)
            {
                if (cameraT.position.x - obstacleT.position.x >= distance)
                {
                    obstacleT.position = new Vector3(obstacleT.position.x + ObstaclesToSpawn * ObstacleDistance,
                                Random.Range(MinY, MaxY), obstacleT.position.z);

                }
            }

        }

    }
    public void turnoffanim()
    {
        foreach (var obstacleT in obstaclesT)
        {
            obstacleT.GetComponent<Animator>().enabled = false;
        }
    }
}
