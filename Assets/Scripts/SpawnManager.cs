﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float treeDistance = 5f;
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
    private float previousTreeRandomizer = 0f;
    private float treeRandomizer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTree();
    }
    private void SpawnTree()
    {
        if (player.transform.position.x >= spawnedTreeCount * treeDistance - 20f)
        {
            float upperBound = Mathf.Min(previousTreeRandomizer + 2.5f, 2.5f); 
            float lowerBound = Mathf.Max(previousTreeRandomizer - 2.5f, -2.5f);
            treeRandomizer = Random.Range(lowerBound,upperBound);
            GameObject spawnedTreeUp = Instantiate(treePrefab, new Vector3(1f+spawnedTreeCount * treeDistance, 16 + treeRandomizer, 0), Quaternion.Euler(0, 0, 180));
            GameObject spawnedTreeDown = Instantiate(treePrefab,new Vector3(1f+spawnedTreeCount * treeDistance, -16 + treeRandomizer, 0),Quaternion.identity);
            previousTreeRandomizer = treeRandomizer;
            spawnedTreeUp.transform.parent = treeContainer.transform;
            spawnedTreeDown.transform.parent = treeContainer.transform;
            spawnedTreeCount++;
        }
    }

}
