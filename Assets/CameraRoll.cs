using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoll : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("ZombieRig");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightShift))
        {
            transform.RotateAround(player.transform.position, Vector3.up, 5f);
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.RotateAround(player.transform.position, Vector3.up, -5f);
        }
    }
}
