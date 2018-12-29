using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    private float distanceBetween;
    private float platformWidth;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;
    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    private CoinGenerator theCoinGenerator;
    private float platformHeight;

    public float randomCoinThreshold;
    public float randomDiamondThreshold;
	// Use this for initialization
	void Start () {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformHeight = thePlatform.GetComponent<BoxCollider2D>().size.y;
        platformWidths = new float[theObjectPools.Length];

        for(int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }


        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        theCoinGenerator = FindObjectOfType<CoinGenerator>();  // locates the only thing with the coingenerator name and places it as a callable object
     }
	
	// Update is called once per frame
	void Update () {
	    
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector]  + distanceBetween, heightChange, transform.position.z);

            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


           /* if(Random.Range(0f,100f) < randomCoinThreshold)
            {
               theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + platformHeight, transform.position.z), (platformWidths[platformSelector] / 3));
               transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2)  + distanceBetween, transform.position.y, transform.position.z);
            } */

            if(Random.Range(0f,100f) <randomDiamondThreshold)
            {
                theCoinGenerator.SpawnDiamonds(new Vector3(transform.position.x, transform.position.y + platformHeight, transform.position.z));
            } else if ( Random.Range(0f,100f) < randomCoinThreshold)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + platformHeight, transform.position.z), (platformWidths[platformSelector] / 3));
                transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);
            }
            
        }

	}
}
