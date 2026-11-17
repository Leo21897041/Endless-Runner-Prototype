using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class ScorekeeperManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public PlayerManager playerManager;

    private void Update()
    {
        if (playerManager != null)
        {
            scoreText.text = "Score: " + playerManager.score.ToString();
        }
    }
}
