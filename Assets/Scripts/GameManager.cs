using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 senserValue = Vector3.zero;

    [Header("UI 관련")] [SerializeField]
    private Text scoreText = null;

    private FoodPoolManager foodPool = null;

    [Header("맵")] [SerializeField]
    private GameObject bowl = null;

    [Header("플레이어")] [SerializeField]
    private GameObject player = null;

    [Header("점수")]
    private int score = 0;

    public ScoreClass sc;

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
    }

    public int GetScore()
    {
        return score;
    }    

    public void MapChange()
    {
        player.transform.localScale = new Vector3(10, 10, 10);
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = string.Concat("Score : ", score);
    }

    [ContextMenu("To Json Data")]
    void SaveHighScore()
    {
        string jsonData = JsonUtility.ToJson(sc);
        string path = Path.Combine(Application.dataPath, "highScore.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("Form Json Data")]
    void LoadHighScore()
    {
        string path = Path.Combine(Application.dataPath, "highScore.json");
        string jsonData = File.ReadAllText(path);
        sc = JsonUtility.FromJson<ScoreClass>(jsonData);
    }
}

[System.Serializable]
public class ScoreClass
{
    public int highScore = 0;
}
