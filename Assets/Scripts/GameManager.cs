﻿using System.Collections;
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
    [SerializeField]
    private Text highScoreText = null;

    private FoodPoolManager foodPool = null;

    [Header("플레이어")] [SerializeField]
    private GameObject player = null;

    [Header("점수")]
    private int score = 0;

    [Header("카메라 애니메이터")] [SerializeField]
    private Animator cameraAnim = null;

    public bool canMovePlayer = true;

    public ScoreClass sc = new ScoreClass();

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

        string strFile = string.Concat(Application.persistentDataPath, "/Score.txt");
        FileInfo fileInfo = new FileInfo(strFile);

        if (fileInfo.Exists)
        {
            LoadHighScore();
        }
        else
        {
            SaveHighScore();
        }

        highScoreText.text = string.Concat("HighScore : ", sc.highScore);
    }

    public int GetScore()
    {
        return score;
    }    

    public void MapChange()
    {
        cameraAnim.Play("CameraUpDown");
        StartCoroutine(StopPlayerMove());
        player.transform.localScale = new Vector3(10, 10, 10);
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = string.Concat("Score : ", score);
    }

    public float GetPlayerScale()
    {
        return player.transform.localScale.x;
    }

    public void SetPlayerScale(float scale)
    {
        player.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void UpdateHighScore()
    {
        if (score > sc.highScore)
        {
            sc.highScore = score;
            SaveHighScore();
            highScoreText.text = string.Concat("HighScore : ", sc.highScore);
        }
    }

    private IEnumerator StopPlayerMove()
    {
        canMovePlayer = false;
        yield return new WaitForSeconds(2f);
        canMovePlayer = true;
    }

    [ContextMenu("To Json Data")]
    public void SaveHighScore()
    {
        string jsonData = JsonUtility.ToJson(sc);
        File.WriteAllText(string.Concat(Application.persistentDataPath, "/Score.txt"), jsonData);
    }

    [ContextMenu("Form Json Data")]
    public void LoadHighScore()
    {
        string jsonData = File.ReadAllText(string.Concat(Application.persistentDataPath, "/Score.txt"));
        sc = JsonUtility.FromJson<ScoreClass>(jsonData);
    }
}

[System.Serializable]
public class ScoreClass
{
    public bool isFirst = false;
    public int highScore = 0;
}
