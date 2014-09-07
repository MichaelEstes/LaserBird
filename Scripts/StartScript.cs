using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	public int textCount;
	public float timer;
	public float maxTime = 1;
	public Animator bird;
	public Animator touchIcon;
	public TextMesh tapText;
	public TextMesh highScoreText;
	public Touch touch;

	void Start () {
		timer = 0;
		textCount = 0;
		tapText.text = "Tap to Fly";
		highScoreText.text = "High Score: " + PlayerPrefs.GetInt ("HighScore").ToString();
	}
	
	void Update () {
		if(timer > maxTime){
			bird.SetTrigger("FlapTrigger");
			touchIcon.SetTrigger("TouchTrigger");
			timer = 0;
			textCount += 1;
			if(textCount > 2){
				tapText.text = "Tap to Start";
			}
		}else{
			timer += 1 * Time.deltaTime;
		}

		if(Application.platform == RuntimePlatform.Android){
			touch = Input.GetTouch (0);
			if(touch.phase == TouchPhase.Began){
				Application.LoadLevel(1);
			}
		}
		if(Input.GetButtonDown("Fire1")){
			Application.LoadLevel(1);
		}
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit(); 
		}
	}
}
