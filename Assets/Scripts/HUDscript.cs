using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDscript : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    public void showHealth(int health)
    {
        healthText.text = health.ToString();
    }

    public void updateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
