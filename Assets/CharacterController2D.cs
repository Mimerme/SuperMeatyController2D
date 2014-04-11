using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {

	public float upSpead;
	public float jumpSpead;
	public bool jumping = false;
	public Vector2 down;
	Vector2 start;
	RaycastHit2D hit;
	void Start(){
		//start = transform.position;
		//start.y = transform.position.y - transform.localScale.y/2f;
		}

	void Update () {
		start = transform.position;
		start.y = transform.position.y - transform.localScale.y/2f - 0.1f;
		Debug.DrawRay (start, -Vector2.up);
		hit = Physics2D.Raycast(start, -Vector2.up,1);
		print (hit.collider);
	;
		if (Input.GetKeyUp(KeyCode.A)) {
			rigidbody2D.velocity = new Vector2(-3,0);
		}
		if (Input.GetKeyUp(KeyCode.D)) {
			rigidbody2D.velocity = new Vector2(3,0);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			jumping = true;
				}
		if (Input.GetKeyUp (KeyCode.Space)) {
			jumping = false;
		}
		if (Input.GetKey (KeyCode.Space)) {
			if(jumping ==true){
			if(rigidbody2D.velocity.y >=10)
				jumping = false;

			rigidbody2D.AddForce(new Vector2(0,jumpSpead * Time.deltaTime));
				}
			}


		//Move Left/Right Code
	if (rigidbody2D.velocity.x >= 9 || rigidbody2D.velocity.x <= -9)
						return;

	if (Input.GetAxisRaw ("Horizontal") < 0) {
			rigidbody2D.AddForce(new Vector2(-upSpead * Time.deltaTime,0));
		}
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			rigidbody2D.AddForce(new Vector2(upSpead * Time.deltaTime,0));
		}


	}
}
