using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    protected Vector3 angleAccler = Vector3.zero;
    protected Vector3 movement = Vector3.zero;

    void Update()
    {
#if UNITY_EDITOR
        if (!GameManager.instance.canMovePlayer) return;

        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        transform.Translate(movement.x, movement.y, movement.z);
#else
        if (!GameManager.instance.canMovePlayer) return;

        angleAccler = Input.acceleration;
        transform.position += new Vector3(angleAccler.x * 3, 0, angleAccler.y * 3);
#endif
    }
}
