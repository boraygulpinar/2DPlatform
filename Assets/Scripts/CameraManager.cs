using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetPlayer;
    public float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(targetPlayer.position.x,targetPlayer.position.y,transform.position.z), cameraSpeed);
    }
}
