using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (GameController._instance == null)
                GameController._instance = FindObjectOfType<GameController>();

            return GameController._instance;
        }
    }

    public Chunk ChunkPrefab;

    [Tooltip("Vitesse global du jeu")]
    [Range(-1, 1)]
    public float speedFactor = 1;

    [Tooltip("Temps de jeu (en s)")]
    [Range(0, 60)]
    public float globalGameTime = 60;
    public float endIntervalTime = 20;

    private bool _gameEnded = false;

    public delegate void ScoreEvent(int nbPoints);
    public event ScoreEvent onScore;

    public AudioSource railSound;

    public GameObject endScreen;

    void Start()
    {
        ChunkController.Instance.StartChunkSpawning();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= globalGameTime && !_gameEnded)
        {
            _gameEnded = true;
            ChunkController.Instance.StopChunkSpawning();
        }
        if (Time.timeSinceLevelLoad >= globalGameTime + endIntervalTime)
        {
            ChunkController.Instance.chunkSpeed = 0;
            railSound.Stop();
            endScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ScorePoint(int nbPoints)
    {
        this.onScore?.Invoke(nbPoints);
    }
}
