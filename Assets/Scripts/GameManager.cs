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
    [SerializeField]
    private Text highScoreText = null;

    [SerializeField]
    private GameObject startPanal = null;
    [SerializeField]
    private GameObject inGamePanal = null;

    [SerializeField]
    private Text titleText = null;
    [SerializeField]
    private Text startText = null;

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
        Screen.SetResolution(1280, 720, true);

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

        startPanal.SetActive(true);
        inGamePanal.SetActive(false);

        canMovePlayer = false;

        highScoreText.text = string.Concat("HighScore : ", sc.highScore);
    }

    public void GameStart()
    {
        startPanal.SetActive(false);
        inGamePanal.SetActive(true);

        canMovePlayer = true;
    }

    public void GameOver()
    {
        startPanal.SetActive(true);
        inGamePanal.SetActive(false);

        titleText.text = "Game Over";
        startText.text = "Tap to restart";
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int n)
    {
        score = n;
        scoreText.text = string.Concat("Score : ", score);
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

    public void ResetPlayerPosition()
    {
        player.transform.position = new Vector3(0, 4, 0);
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
