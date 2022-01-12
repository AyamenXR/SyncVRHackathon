using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ChickenFarm
{
    public class Score : MonoBehaviour
    {
        public GameObject feedScoreText;
        private void OnEnable()
        {
            GameManager.WhenAnimalFed += DisplayScore;
        }

        private void OnDisable()
        {
            GameManager.WhenAnimalFed -= DisplayScore;
        }

        private void DisplayScore()
        {
            feedScoreText.GetComponent<TextMeshProUGUI>().text = GameManager.feedScore.ToString();
        }
    }
}

