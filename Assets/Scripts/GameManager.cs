using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 senserValue = Vector3.zero;

    [Header("UI 관련")] [SerializeField]
    private Text value = null;

    private FoodPoolManager foodPool = null;

    [Header("메인 카메라")] [SerializeField]
    private GameObject mainCam = null;
    [Header("맵")] [SerializeField]
    private GameObject bowl = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        foodPool = FindObjectOfType<FoodPoolManager>();

        foodPool.Pooling();
        foodPool.Pooling();
    }
    void Update()
    {
        senserValue = Input.acceleration;

        value.text = string.Concat("X ", senserValue.x, ", ", "Z ", senserValue.y);
    }

    public void MapChange()
    {
        mainCam.transform.position += new Vector3(0, 100, 0);
        bowl.transform.localScale += new Vector3(1, 0, 1);
    }
}
