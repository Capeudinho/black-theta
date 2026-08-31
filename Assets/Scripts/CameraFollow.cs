using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;

    void Start(){
    }

    void LateUpdate(){
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
