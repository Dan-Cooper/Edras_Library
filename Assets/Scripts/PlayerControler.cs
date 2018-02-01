using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerControler : MonoBehaviour
{
	private CharacterController charControl;
	//private Rigidbody rb;
	
	public float walkSpeed;
	
	[Range(1,10)]
	public float jumpVelocity;

	public float gravity;
	
	public float fallMultiplier;
	public float lowJumpMultiplier;

	private bool jumpRequest;
	private Vector3 moveDir;

	// Use this for initialization
	void Awake()
	{
		charControl = GetComponent<CharacterController>();
		//rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown("Jump") && charControl.isGrounded)
		{
			jumpRequest = true;
		}
		MovePlayer();
	}
/* Was used in simplemove might bring back.
	void FixedUpdate()
	{
		if (jumpRequest)
		{
			moveDir.y = jumpVelocity;
			jumpRequest = false;
		}
		//TunedJump();
	}
*/
	void MovePlayer()
	{
		if (charControl.isGrounded)
		{
			//Debug.Log("Grounded");
			moveDir = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
			moveDir = transform.TransformDirection(moveDir);
			moveDir *= walkSpeed;
			if (jumpRequest)
			{
				moveDir.y = jumpVelocity;
				jumpRequest = false;
			}
		}
		moveDir.y -= gravity * Time.deltaTime;
		charControl.Move(moveDir * Time.deltaTime);
		
		
		/*Breaking simple move so player can preform a basic jump.
		//Gets Raw input data
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		//Modifies data for speed and direction
		Vector3 moveSide = transform.right * h * walkSpeed;
		Vector3 moveForw = transform.forward * v * walkSpeed;
		//Makes change to object
		charControl.SimpleMove(moveSide);
		charControl.SimpleMove(moveForw);
		*/
	}
	
	/*//Adjusts the jump hight based on how long the jump key is presed
	//NEEDS TO BE REWRITEN FOR THE NEW MOVER SCRIPT
	//TODO
	void TunedJump()
	{
		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
		{
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}
	*/
}
