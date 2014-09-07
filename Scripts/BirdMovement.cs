using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	public bool alive;
	public float timer;
	public float deathTime = 1.5f;
	public float moveSpeed = 5;
	public float flySpeed;
	public float flySpeedAndroid;
	public Vector2 velocity;
	public Vector2 stop = new Vector2 (0, 0);
	public Vector2 flipSprite;
	public Animator birdAnimator;
	public Touch touch;
	public Score score;
	public GameObject feather;

	void Start () {
		alive = true;
		timer = 0;
		velocity.x = moveSpeed;
		flySpeed = 300;
		flySpeedAndroid = 100;
		this.rigidbody2D.velocity = velocity;
	}
	
	void Update () {
		if(alive){
			if(Application.platform == RuntimePlatform.Android){
				touch = Input.GetTouch (0);
				if(touch.phase == TouchPhase.Began){
					this.rigidbody2D.AddForce(Vector2.up * flySpeedAndroid);
				}
			}
			if(Input.GetButtonDown("Fire1")){
				birdAnimator.SetTrigger("FlapTrigger");
				this.rigidbody2D.AddForce(Vector2.up * flySpeed);
			}
		}else{
			if(timer < deathTime){
				timer+= 1 * Time.deltaTime;
			}else{
				Application.LoadLevel(0);
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit(); 
		}
	}

	public virtual void Death(){
		alive = false;
		Instantiate (feather, this.transform.position, transform.rotation);
		Instantiate (feather, this.transform.position, transform.rotation);
		Instantiate (feather, this.transform.position, transform.rotation);
		Instantiate (feather, this.transform.position, transform.rotation);
		Instantiate (feather, this.transform.position, transform.rotation);
		Instantiate (feather, this.transform.position, transform.rotation);
		Instantiate (feather, this.transform.position, transform.rotation);
		Instantiate (feather, this.transform.position, transform.rotation);
		score.CheckMaxScore ();
		this.rigidbody2D.velocity = stop;
		this.rigidbody2D.gravityScale = 0;
		this.renderer.enabled = false;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.name == "WallLeft" || collision.gameObject.name == "WallRight"){
			velocity.x = moveSpeed *= -1;
			flipSprite = this.transform.localScale;
			flipSprite.x *= -1;
			this.rigidbody2D.velocity = velocity;
			this.transform.localScale = flipSprite;
			score.AddScore();
		}else{
			Death ();
		}
	}
}
