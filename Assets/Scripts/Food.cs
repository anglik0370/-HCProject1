using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private FoodPoolManager foodPool = null;

    private void Start()
    {
        foodPool = FindObjectOfType<FoodPoolManager>();
    }

    private void OnTriggerEnter(Collider col)
    {
        foodPool.Pooling();
        gameObject.SetActive(false);

        col.gameObject.transform.localScale += new Vector3(1, 1, 1);

        GameManager.instance.UpdateScore();

        if ((col.gameObject.transform.localScale.x % 30).Equals(0))
        {
            GameManager.instance.MapChange();
        }
    }
}
