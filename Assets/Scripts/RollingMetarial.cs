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

        transform.rotation = Quaternion.Euler(transform.rotation.z + movement.z * 180 + transform.rotation.z, 0, transform.rotation.x + movement.x * 180 + transform.rotation.x);
#else
        if (!GameManager.instance.canMovePlayer) return;

        angleAccler = Input.acceleration;
        transform.rotation = Quaternion.Euler(transform.rotation.z + angleAccler.z * 180 + transform.rotation.z, 0, transform.rotation.x + angleAccler.x * 180 + transform.rotation.x);
#endif
    }
}
