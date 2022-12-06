using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {
    [SerializeField] private GameObject ScoreObject;
    [SerializeField] private ShootBall shootBall;
    private TextMeshProUGUI ScoreText;


    private void Start() {
        ScoreText = ScoreObject.GetComponent<TextMeshProUGUI>();
    }
    private void Update() {
        ScoreText.text = "Score: "+shootBall.amountOfShoots.ToString();
    }
    public void GoToMainMenu() {
        SceneManager.LoadScene(0);
    }
    public void GoToNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); // borde gör en check att det inte är sista
    }
}
