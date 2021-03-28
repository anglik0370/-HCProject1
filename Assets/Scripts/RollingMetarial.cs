using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingMetarial : PlayerMove
{
    void Update()
    {
#if UNITY_EDITOR
        if (!GameManager.instance.canMovePlayer) return;

        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        transform.rotation = Quaternion.Euler(movement.z * 180 + transform.rotation.z, 0, movement.x * 180 + transform.rotation.x);
#else
        if (!GameManager.instance.canMovePlayer) return;

        transform.position += new Vector3(angleAccler.x, 0, angleAccler.y);
#endif
    }
}
