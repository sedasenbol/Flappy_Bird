using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        Screen.SetResolution(1242, 2208, true);
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 1.5f, 0f, player.transform.position.z - 5f);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
