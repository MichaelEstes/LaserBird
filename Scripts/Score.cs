using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score;
	public int highScore;
	public int scoreCheck;
	public TextMesh scoreText;
	public Renderer scoreTextRender;
	public GameObject laser;

	void Start () {
		score = 0;
		scoreTextRender.sortingLayerName = "UI";
		scoreText.text = score.ToString ();
		highScore = PlayerPrefs.GetInt ("HighScore");
	}
	
	void Update () {
	
	}

	public virtual void AddScore(){
		score += 1;
		scoreText.text = score.ToString ();
		scoreCheck += 1;
		if(scoreCheck == 4){
			Instantiate(laser, new Vector2(0,0), transform.rotation);
			scoreCheck = 0;
		}
	}

	public virtual void CheckMaxScore(){
		if(score > highScore){
			PlayerPrefs.SetInt("HighScore", score);
		}
	}
}
