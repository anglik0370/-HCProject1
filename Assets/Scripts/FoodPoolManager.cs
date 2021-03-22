using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPoolManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> foods = new List<GameObject>();

    public void Pooling()
    {
        float xPos = Random.Range(-40f, 40f);
        float zPos = Random.Range(-20f, 20f);
        float yPos = 4f;

        for (int i = 0; i < 3; i++)
        {
            if (foods[i].activeSelf.Equals(false))
            {
                foods[i].transform.position = new Vector3(xPos, yPos, zPos);
                foods[i].SetActive(true);
                return;
            }
        }
    }
}
