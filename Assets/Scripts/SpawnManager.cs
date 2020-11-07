using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float treeDensity = 6f;
    [SerializeField]
    private GameObject treePrefab;
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private GameObject treeContainer;
    [SerializeField]
    private GameObject coinContainer;
    private GameObject player;
    private int spawnedTreeCount=0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTreeAndCoin();
    }
    private void SpawnTreeAndCoin()
    {
        if(player.transform.position.x >= spawnedTreeCount * treeDensity-20)
        {
            float treeRandomizer = Random.Range(-3, 4);
            GameObject spawnedTreeUp1 = Instantiate(treePrefab, new Vector3(-10+spawnedTreeCount*treeDensity, 29+ treeRandomizer, 0), Quaternion.Euler(0, 0, 180));
            GameObject spawnedTreeDown1 = Instantiate(treePrefab,new Vector3(-5+spawnedTreeCount*treeDensity,-29 + treeRandomizer, 0),Quaternion.identity);
            //GameObject spawnedCoin = Instantiate(coinPrefab, new Vector3(4.5f+spawnedTreeCount*treeDensity,treeRandomizer,0),Quaternion.identity);
            //spawnedCoin.transform.parent = coinContainer.transform;
            spawnedTreeUp1.transform.parent = treeContainer.transform;
            spawnedTreeDown1.transform.parent = treeContainer.transform;
            spawnedTreeCount++;
        }
    }

}
