using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TreeScript : MonoBehaviour
{
    private GameObject player;
    private readonly float speed = 0.012f;
    private float startingYPosition;
    private MeshRenderer myMeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startingYPosition = transform.position.y;
        myMeshRenderer = GetComponent<MeshRenderer>();
        myMeshRenderer.sortingLayerName = "Tree";
        myMeshRenderer.sortingOrder = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
        Move();
    }
    private void Destroy()
    {
        if (player.transform.position.x > transform.position.x + 35f)
        {
            Destroy(this.gameObject);
        }
    }
    private void Move()
    {
        if (startingYPosition > 0f && transform.position.y >= -7.8f + startingYPosition)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }
        else if (startingYPosition < 0f && transform.position.y <=  7.8f + startingYPosition)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }
    }
}
