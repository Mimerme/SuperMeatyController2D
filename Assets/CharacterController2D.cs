using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {

	public float upSpead;
	public float jumpSpead;
	public bool jumping = false;
	public bool grounded = false;
	public string sidesHit = "none";
	public Vector2 down;
	public Vector2 sides;
	public Vector2 sideLeft;
	public float skinWidth = 0.1f;
	public float InitalAcceleration = 500;

	Vector2 start;
	RaycastHit2D hit;
	void Start(){

		//start = transform.position;
		//start.y = transform.position.y - transform.localScale.y/2f;
		}

	void Update () {
	//Basic ground checking code with Physics2d raycasting
		sideLeft = transform.position;
		sideLeft.x = transform.position.x - transform.localScale.x / 2 - 0.1f;
		sides = transform.position;
		sides.x = transform.position.x + transform.localScale.x / 2 + 0.1f;
		start = transform.position;
		start.y = transform.position.y - transform.localScale.y/2f - 0.1f;
		Debug.DrawRay (start, -Vector2.up);
		Debug.DrawRay (sides, Vector2.right);
		Debug.DrawRay (sideLeft, -Vector2.right);
		if (Physics2D.Raycast (start, -Vector2.up, 1).collider != null) {
						grounded = true;
				} else {
			grounded = false;
				}

	
		if (Input.GetKeyUp(KeyCode.A)) {
			//Detect when certain keys are released to reset velocity
			//Reset the velocity to a number close to 0 to make a sudden stop, but ease out to fell smoother
			rigidbody2D.velocity = new Vector2(-3,0);
		}
		if (Input.GetKeyUp(KeyCode.D)) {
			rigidbody2D.velocity = new Vector2(3,0);
		}
		//Jumping Trigger
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(grounded == true){
			jumping = true;
				//Add the Initial Accleration to make the player shoot up, and then slow down, then fall
				rigidbody2D.AddForce(new Vector2(0,InitalAcceleration));

			}
				}
		if (Input.GetKeyUp (KeyCode.Space)) {
			jumping = false;
		}
		if (Input.GetKey (KeyCode.Space)) {
			if(jumping ==true){
				//Detect if speed limit is reached, and then fall back down
			if(rigidbody2D.velocity.y >=10){
				jumping = false;
				}
				rigidbody2D.AddForce(new Vector2(0,jumpSpead * Time.deltaTime));


				}
			}
		//Detect sides by raycastting. Possibly can be used for wall jumping
		if (Physics2D.Raycast (sides, Vector2.right, skinWidth).collider != null) {
						sidesHit = "right";
		} else if (Physics2D.Raycast (sideLeft, -Vector2.right, skinWidth).collider != null) {
			sidesHit = "left";
				}
			else {
			sidesHit = "none";
			
		}

		Move ();



	}
	void Move(){
		//Move Left/Right Code
		if (rigidbody2D.velocity.x >= 9 || rigidbody2D.velocity.x <= -9)
			return;
		
		if (Input.GetAxisRaw ("Horizontal") < 0 && sidesHit != "left") {
			rigidbody2D.AddForce(new Vector2(-upSpead * Time.deltaTime,0));
		}
		if (Input.GetAxisRaw ("Horizontal") > 0 && sidesHit != "right") {
			rigidbody2D.AddForce(new Vector2(upSpead * Time.deltaTime,0));
		}
	}
}
