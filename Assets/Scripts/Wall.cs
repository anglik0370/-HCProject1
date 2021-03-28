using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private GameObject startUI = null;

    private void OnCollisionEnter(Collision col)
    {
        float playerScale = GameManager.instance.GetPlayerScale();

        if (playerScale - 5 <= 10)
        {
            GameManager.instance.SetPlayerScale(playerScale);
            GameManager.instance.ResetPlayerPosition();
            GameManager.instance.SetScore(0);
            GameManager.instance.canMovePlayer = false;
            startUI.SetActive(true);
        }
        else
        {
            col.transform.localScale -= new Vector3(5, 5, 5);
        }
    }
}
