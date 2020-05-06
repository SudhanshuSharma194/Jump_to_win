using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilegenerator : MonoBehaviour
{
    // No of tiles to spawn at start
    public int TilesToSpawn = 10;
    // Distance between two tiles
    public int TileDistance = 3;
    // Min and Max position (y) of pipe
    public float MinY;
    public float MaxY;
    // Parent object, (usually a empty object)
    public Transform Tiles;
    // Tile prefab
    public GameObject Tile;

    private List<Transform> tilesT = new List<Transform>();
    private Transform cameraT;
    private float distance = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
         
          cameraT = Camera.main.transform;
        for (int i = 0; i < TilesToSpawn; ++i)
        {
            // Creates a new instance of the tile 
            GameObject tile = Instantiate(Tile) as GameObject;
            // Reference to the transform component
            Transform tileTransform = tile.transform;
            tilesT.Add(tileTransform);

            // Modifying X and Y position of tile
            tileTransform.position = new Vector3(tileTransform.position.x + ((i + 1) * TileDistance), Random.Range(MinY,MaxY), tileTransform.position.z);
            // tileTransform.parent = Tiles;

        }
        
    }

        // Update is called once per frame
        void Update()
    {
            foreach (var tileT in tilesT)
            {
                if (tileT.position.x < cameraT.position.x)
                {
                    if (cameraT.position.x - tileT.position.x >= distance)
                    {
                        tileT.position = new Vector3(tileT.position.x + TilesToSpawn * TileDistance,
                                    Random.Range(MinY, MaxY), tileT.position.z);

                    }
                }

            }
      
    }
    }
