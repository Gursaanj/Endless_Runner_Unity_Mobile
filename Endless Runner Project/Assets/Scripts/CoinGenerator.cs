using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    //public ObjectPooler coinPool;
    //public ObjectPooler silverCoinPool;
    public ObjectPooler[] theCoinPools;
    private int coin1Select;
    private int coin2Select;
    private int coin3Select;
    public ObjectPooler theDiamondPool;
    
    //public float distanceBetweenCoins;

    // Use this for initialization
    void Update()
    {
        coin1Select = Random.Range(0, theCoinPools.Length);
        coin2Select = Random.Range(0, theCoinPools.Length);
        coin3Select = Random.Range(0, theCoinPools.Length);
    }

    public void SpawnCoins(Vector3 startPosition, float dist)
    {
        GameObject coin1 = theCoinPools[coin1Select].GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = theCoinPools[coin2Select].GetPooledObject();
        coin2.transform.position = new Vector3(startPosition.x - dist, startPosition.y, startPosition.z);
        coin2.SetActive(true);

        GameObject coin3 = theCoinPools[coin3Select].GetPooledObject();
        coin3.transform.position = new Vector3(startPosition.x + dist, startPosition.y, startPosition.z);
        coin3.SetActive(true);
    }

    public void SpawnDiamonds(Vector3 startPosition)
    {
        GameObject diamond = theDiamondPool.GetPooledObject();
        diamond.transform.position = startPosition;
        diamond.SetActive(true);
    }
}
