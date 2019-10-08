using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;
    public float FollowSpeed;
    public bool follow;
    float timeToReachEndPoint = 5;
    float timeToReachPlayer = 2;
    float timePast = 0;
    public bool goToPlayer;
    public bool timeOut;
    public bool win;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goToPlayer)
        {
            moveToPlayer();
        }

        if (follow)
        {
            FollowPlayer();
        }
        if (timeOut || win)
        {
            goToEndCameraPosition();
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position + Offset, FollowSpeed);
    }

    void moveToPlayer()
    {
        var cameraPosition = transform.position;
        var playerPosition = Player.position;
        timePast += Time.deltaTime / timeToReachPlayer;
        transform.position = Vector3.Lerp(cameraPosition, playerPosition, timePast);
        if(Vector3.Distance(transform.position, Player.position) < 0.1f)
        {
            follow = true;
            goToPlayer = false;
            timePast = 0;
        }
        
    }

    void goToEndCameraPosition()
    {
        var endCameraPosition = GameObject.FindGameObjectWithTag("endcamera").transform.position; // here goes camera endposition tag
        timePast += Time.deltaTime / timeToReachEndPoint;
        transform.position = Vector3.Lerp(transform.position, endCameraPosition, timePast);
    }
}
