using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



public class Point:MonoBehaviour
{

    public Transform Player;
    public int score;
    

    public void OnPlayerCollision()
    {
/*        var randomX = UnityEngine.Random.Range(-9.5f, 9.5f);
        var randomZ = UnityEngine.Random.Range(-9.5f, 9.5f);

        transform.position = new Vector3(randomX, 1.0f, randomZ);*/
        // TODO GameObject.FindGameObjectsWithTag("Spawn"); lista obiektów z tagiem do spawnawania pointów najlepiej najdalej od gracza
        // wymyslec feature do tej gry
        var spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        bool goodPoint = false;
        while (!goodPoint)
        {
            var index = UnityEngine.Random.Range(0, spawnPoints.Length);
            var pickedPoint = spawnPoints[index];
            var distanceToPlayer = Vector3.Distance(Player.position, pickedPoint.transform.position);
            if(distanceToPlayer > 3)
            {
                goodPoint = true;
                transform.position = pickedPoint.transform.position;
            }
        }
        addScore();

    }
    public void addScore()
    {
        score++;
    }

    public void resetScore()
    {
        score = 0;
    }
}

