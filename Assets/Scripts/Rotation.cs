using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float fact = 10f;
   
    void Update()
    {
        transform.Rotate(0,fact*Time.deltaTime,0);
    }
}
