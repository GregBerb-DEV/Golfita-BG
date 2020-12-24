﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Interface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreDisplay = default;
    [SerializeField] private TextMeshProUGUI _parDisplay = default;
    [SerializeField] private TextMeshProUGUI _shotsDisplay = default;
    [SerializeField] private TextMeshProUGUI _shotNameDisplay = default;
    [SerializeField] private Image imagem = default;


    void Start()
    {
        UpdateScoreDisplay(ScoreManager.Instance._totalScore);
        UpdateParDisplay(ScoreManager.Instance._currentScenePar);
    }

    public void UpdateShotsDisplay(int shotAmount)
    {
        _shotsDisplay.SetText($"Tacadas: {shotAmount}");
    }

    public void UpdateScoreDisplay(int totalScore)
    {
        _scoreDisplay.SetText($"Pontuação Total: {totalScore}");
    }

    public void UpdateShotNameDisplay(int score)
    {
        _shotNameDisplay.SetText($"ALBATROZ");
    }

    public void UpdateParDisplay(int par)
    {
        _parDisplay.SetText($"Par: {par}");
    }
}
