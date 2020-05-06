using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coingenerator : MonoBehaviour
{
    // No of coins to spawn at start
    public int CoinsToSpawn = 10;
    // Distance between two coins
    public int CoinDistance = 3;
    // Min and Max position (y) of coin
    public float MinY;
    public float MaxY;
    // Parent object, (usually a empty object)
    public Transform Coins;
    // Coin prefab
    public GameObject Coin;
    float distance = 15.0f;
    private List<Transform> coinsT = new List<Transform>();
    //private List<Transform> coinsT1 = new List<Transform>();
    private Transform cameraT;
    void Start()
    {
        cameraT = Camera.main.transform;
        for (int i = 0; i < CoinsToSpawn; ++i)
        {
            // Creates a new instance of the coin 
            GameObject coin = Instantiate(Coin) as GameObject;
            // Reference to the transform component
            Transform coinTransform = coin.transform;
            coinsT.Add(coinTransform);
            

            // Modifying X and Y position of coin
            coinTransform.position = new Vector3(coinTransform.position.x + ((i + 1) * CoinDistance), Random.Range(MinY, MaxY), coinTransform.position.z);
            // coinTransform.parent = Coins;

        }
    }
    void Update()
    {
        foreach (var coinT in coinsT)
        {
            if (coinT.position.x < cameraT.position.x)
            {
               
                if (cameraT.position.x - coinT.position.x >= distance)
                {
                    coinT.GetComponent<SpriteRenderer>().enabled = true;
                    coinT.position = new Vector3(coinT.position.x + CoinsToSpawn * CoinDistance, Random.Range(MinY, MaxY), coinT.position.z);
                    
                }
                
            }

        }

    }



}
