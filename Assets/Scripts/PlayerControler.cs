using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerControler : MonoBehaviour
{
	private CharacterController charControl;
	//private Rigidbody rb;
	
	public float walkSpeed;
	private bool sprintRequest;
	
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
		
		if (Input.GetButtonDown("Jump") && charControl.isGrounded) jumpRequest = true;
		if (Input.GetButtonDown("Run")) walkSpeed *= 2;
		if (Input.GetButtonUp("Run")) walkSpeed /= 2;
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
		if (moveDir.y < 0.2)
		{
			moveDir += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
			//Debug.Log("Long" + moveDir.y);
		}
		else if (moveDir.y > 0.2 && !Input.GetButton("Jump"))
		{
			moveDir += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
			//Debug.Log("short" + moveDir.y);
		}
		//Debug.Log("Move" + moveDir);
		moveDir.y -= gravity * Time.deltaTime;
		charControl.Move(moveDir * Time.deltaTime);
	}
}
