using UnityEngine;
using System.Collections;

public class FeatherMovement : MonoBehaviour {

	public float timer;
	public float forceTime = 1;
	public Vector2 randomDir;
	public float featherForce = 50;

	void Start () {
		if(this.gameObject.name != "Feather"){
			this.rigidbody2D.gravityScale = 0.1f;
			randomDir.x = Random.Range (-1.0f, 1.0f);
			randomDir.y = Random.Range (-1.0f, 1.0f);
			this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, Random.Range(0, 360)));
			this.rigidbody2D.AddForce(randomDir * featherForce);
		}
	}
	
	void Update () {

	}
}