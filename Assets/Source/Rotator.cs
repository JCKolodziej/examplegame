using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Rotator:MonoBehaviour
{
    public Vector3 Rotation;
    private void Update()
    {
        transform.Rotate(Rotation * Time.deltaTime);
    }
}

