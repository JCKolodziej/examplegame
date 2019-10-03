using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Obstacle:MonoBehaviour
{
    public enum MovementType
    {
        Lerp,
        MoveTowards,
        Translate
    }
    public readonly MovementType Type = MovementType.MoveTowards;
    public Vector3 Movement;
    public float Speed;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool _reverse;
    private float startTime;

    private void Start()
    {
        //Moving object
        //Vector3.Lerp; => ruch z a do b ze stałą prędkością t = <0,1>
        //Vector3.MoveTowards; => delta długości na klatkę, lepsze do ruchu zmiennego
        //transform.Translate; => obliczanie vectora przemieszczenia dzielony na czas przemieszczenia

        // Vector3.Distance => bezwględna odległość do celu

        startPosition = transform.position;
        endPosition = startPosition + Movement;
        _reverse = false;
        startTime = Time.time;
    }

    private void Update()
    {
        switch (Type)
        {
            case MovementType.Lerp:
            {
                    var totalDist = Vector3.Distance(startPosition, endPosition);
                    var currDist = (Time.time - startTime) * Speed;

                    var t = currDist / totalDist;
                    transform.position = Vector3.Lerp(_reverse ? endPosition : startPosition, _reverse ? startPosition : endPosition, t);
                    break;
            }
            case MovementType.MoveTowards:
            {
                    transform.position = Vector3.MoveTowards(transform.position, _reverse ? startPosition : endPosition, Speed * Time.deltaTime);
                    break;
            }
            case MovementType.Translate:
            {
                    var movement = _reverse ? endPosition - startPosition : startPosition - endPosition;
                    var dir = movement.normalized;

                    transform.Translate(dir * Speed * Time.deltaTime);

                    break;
            }
                
        }

        var dist = Vector3.Distance(transform.position, _reverse ? startPosition : endPosition);
        if (dist < 0.05f)
            {   

                startTime = Time.time;
                _reverse = !_reverse;
            }
        //float step = Speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, endPosition, step);

        //if (Vector3.Distance(transform.position, endPosition) < 0.01f)
        //{
        //    Vector3 temporary = startPosition;
        //    startPosition = endPosition;
        //    endPosition = temporary;
        //}
    }
}

