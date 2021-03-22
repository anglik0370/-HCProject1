using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 angleAccler = Vector3.zero;
    private Vector3 movement = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
#if UNITY_EDITOR
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        transform.Translate(movement.x, movement.y, movement.z);
#else
        angleAccler = Input.acceleration;
        transform.position += new Vector3(angleAccler.x, 0, angleAccler.y);
#endif
    }
}
