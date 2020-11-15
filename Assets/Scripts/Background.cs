using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 1, transform.position.y,transform.position.z);
    }
}
