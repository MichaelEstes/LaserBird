using UnityEngine;
using System.Collections;

public class LaserScale : MonoBehaviour {

	public float startTime = 1.0f;
	public float laserTime = 2.0f;
	public float timer;
	public Vector2 startScale = new Vector2 (0.1f, 0.08f);
	public Vector2 addScale = new Vector2 (0.02f, 0);
	public Vector2 newPos;
	public Animator laserAnimator;
	public BoxCollider2D laserCollider;
	public enum State{start, fire, stall, end};
	public State state;

	void Start () {
		state = State.start;
		timer = 0;
		laserCollider.size = startScale;
		this.transform.position = new Vector3 (6, Random.Range (-9.5f, 9.5f), 0);
	}
	
	void Update () {

		if (state == State.start) {
			StartTimer (startTime, State.fire, "FireTrigger");
		}else if(state == State.fire){
			StartTimer(startTime, State.stall, "StallTrigger");
			laserCollider.size += addScale;
		}else if(state == State.stall){
			StartTimer(laserTime, State.end, "StartTrigger");
		}else{
			Start();
		}
	}

	void StartTimer(float time, State newState, string trigger){
		if(time > timer){
			timer += 1 * Time.deltaTime;
		}else{
			timer = 0;
			state = newState;
			laserAnimator.SetTrigger(trigger);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.name == "Bird"){
			collider.gameObject.GetComponent<BirdMovement>().Death();
		}
	}
}
