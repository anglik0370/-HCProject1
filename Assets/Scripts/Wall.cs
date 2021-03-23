using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        col.transform.localScale -= new Vector3(5, 5, 5);
    }
}
