using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        float playerScale = GameManager.instance.GetPlayerScale();

        if (playerScale - 5 <= 10)
        {
            GameManager.instance.SetPlayerScale(playerScale);
            Debug.Log("게임오버");
        }
        else
        {
            col.transform.localScale -= new Vector3(5, 5, 5);
        }
    }
}
