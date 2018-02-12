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

    [Range(1, 10)] public float jumpVelocity;

    public float gravity;

    public float fallMultiplier;
    public float lowJumpMultiplier;

    private bool jumpRequest;
    private Vector3 moveDir = new Vector3(0,0,0);


    private bool fDetect;
    private bool lDetect;
    private bool rdetect;

   [SerializeField] private float climbVelocity;
   [SerializeField] private float climbDecay = 0;

    // Use this for initialization
    void Awake()
    {
        charControl = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ParcoreDetetion();

        if (Input.GetButtonDown("Jump") && charControl.isGrounded) jumpRequest = true;
        if (Input.GetButtonDown("Run")) walkSpeed *= 2;
        if (Input.GetButtonUp("Run")) walkSpeed /= 2;
        if (fDetect && !charControl.isGrounded)  //To Slow rait of climb as climb progresses.
        {
            climbDecay += Mathf.Lerp(0,8,(Time.deltaTime / 1f));
        }

        MovePlayer();
    }

/*// Was used in simplemove might bring back.
    void FixedUpdate()
    {
        if (jumpRequest)
        {
            Debug.Log("JR" + jumpVelocity);
            moveDir.y = jumpVelocity;
            jumpRequest = false;     
        }
        fDetect = false;
        //moveDir.y -= gravity * Time.fixedDeltaTime;
        //charControl.Move(moveDir * Time.fixedDeltaTime);
    }*/

    void MovePlayer()
    {
        if (charControl.isGrounded)
        {
            //Debug.Log("Jump" + jumpRequest);
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= walkSpeed;
            if (jumpRequest)
            {
                moveDir.y = jumpVelocity;
                jumpRequest = false;
            }
            fDetect = false;
            climbDecay = 0;
        }
        if (fDetect)
        {
            moveDir.y = climbVelocity - climbDecay;
        }
        if (moveDir.y < 0.2)
        {
            moveDir += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            Debug.Log("Long" + fDetect);
        }
        else if (moveDir.y > 0.2 && !Input.GetButton("Jump"))
        {
            moveDir += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            Debug.Log("short"+ fDetect);
        }
        //Debug.Log("Move" + moveDir.y);
        moveDir.y -= gravity * Time.deltaTime;
        charControl.Move(moveDir * Time.deltaTime);
    }


    //Fires Raycasts around the player at center and top of prefab.
    void ParcoreDetetion()
    {
        Vector3 mFwd = transform.TransformDirection(Vector3.forward); //Forword DIR
        Ray rMfRay = new Ray(transform.position, mFwd);
        Ray rHfRay = new Ray(transform.position + new Vector3(0, 1.5f, 0), mFwd);

        if (Physics.Raycast(rMfRay, 1)) fDetect = true;
        if (!Physics.Raycast(rMfRay, 1)) fDetect = false;

        Vector3 mLft = transform.TransformDirection(Vector3.left); //Left DIR
        Ray rMlRay = new Ray(transform.position, mLft);
        Ray rHlRay = new Ray(transform.position + new Vector3(0, 1.5f, 0), mLft);

        Vector3 mRgt = transform.TransformDirection(Vector3.right); //Right DIR
        Ray rMrRay = new Ray(transform.position, mRgt);
        Ray rHrRay = new Ray(transform.position + new Vector3(0, 1.5f, 0), mRgt);

        if (true) //Set to True to show Debug Rays
        {
            Debug.DrawRay(transform.position, mFwd, Color.yellow); //Mid Forword
            Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), mFwd, Color.yellow); //High Forword

            Debug.DrawRay(transform.position, mLft, Color.red); //Mid Left
            Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), mLft, Color.red); //High Left

            Debug.DrawRay(transform.position, mRgt, Color.green); //Mid Right
            Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), mRgt, Color.green); //High Right
        }
    }
}