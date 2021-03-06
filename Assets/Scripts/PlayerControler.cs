﻿using System.CodeDom.Compiler;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    private CharacterController _charControl;
    private Vector3 OsdForce;
    public float ForceMult;

    //public Image Black;

    //public float TransitionSpeed;
    //private Rigidbody rb;

    public GameObject Ledge;
    public bool LedgeSpawned;

    public float WalkSpeed;
    private bool _sprintRequest;

    [Range(1, 10)] public float JumpVelocity;

    public float Gravity;

    public float FallMultiplier;
    public float LowJumpMultiplier;

    private float _health = 100;

    private bool _jumpRequest;
    private Vector3 _moveDir = new Vector3(0,0,0);


    private bool _fDetect;
    private bool _lDetect;
    private bool _rDetect;
    private bool _wallContact;

    [SerializeField] private float _climbVelocity;
    private float _climbDecay;

    private bool _dead;
    private bool _beingDamaged;
    private bool _healing;

    // Use this for initialization
    void Awake()
    {
        _charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0)
        {
            Debug.Log("Dead");
            _dead = true;
        }
        if (_health < 100 && _healing)
            _health += 1;
        if(_dead && Input.anyKeyDown)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        StartCoroutine(Heal());
        
        ParcoreDetetion();

        if (Input.GetButtonDown("Jump") && _charControl.isGrounded) _jumpRequest = true;
        if (Input.GetButtonDown("Run")) WalkSpeed *= 2;
        if (Input.GetButtonUp("Run")) WalkSpeed /= 2;
        
        if (_lDetect || _rDetect || _fDetect) _wallContact = true;
        else _wallContact = false;
        
        if ((_fDetect || _rDetect || _lDetect) && !_charControl.isGrounded)  //To Slow rait of climb as climb progresses.
        {
            _climbDecay += Mathf.Lerp(0,8,(Time.deltaTime / 1f));
        }

        if(!_dead)MovePlayer();
        //else Black.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, TransitionSpeed * Time.deltaTime);
        OsdForce=new Vector3(0,0,0);
    }

    //ForWallJump Not used for build
    void Jump()
    {
        if (_jumpRequest && !_wallContact)
        {
            _moveDir.y = JumpVelocity;
            _jumpRequest = false;
        }
        if (_jumpRequest && _wallContact)
        {
            if (_fDetect)
            {
                _moveDir.y = JumpVelocity;
                _moveDir.z = -JumpVelocity;
            }
            if (_lDetect)
            {
                _moveDir.y = JumpVelocity;
                _moveDir.x = -JumpVelocity;
            }
            if (_rDetect)
            {
                _moveDir.y = JumpVelocity;
                _moveDir.x = JumpVelocity;
            }
            
        }
    }

    void MovePlayer()
    {
        if (_charControl.isGrounded || _wallContact)
        {
            if (_charControl.isGrounded)
            {
                //Debug.Log("Jump" + jumpRequest);
                _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                _moveDir = transform.TransformDirection(_moveDir);
                _moveDir *= WalkSpeed;
            }
            //Jump();
            if (_jumpRequest)
            {
                _moveDir.y = JumpVelocity;
                _jumpRequest = false;
            }
            if (_charControl.isGrounded)
            {
                _fDetect = false;
                _lDetect = false;
                _rDetect = false;

                _climbDecay = 0;
            }
        }
        
        Parcore();
        
        if (_moveDir.y < 0.2) //Long Jump
        {
            _moveDir += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
            //Debug.Log("Long" + _fDetect);
        }
        else if (_moveDir.y > 0.2 && !Input.GetButton("Jump")) //Short Jump
        {
            _moveDir += Vector3.up * Physics.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
            //Debug.Log("short"+ _fDetect);
        }
        //Debug.Log("Move" + moveDir.y);
        _moveDir.y -= Gravity * Time.deltaTime;
        _moveDir += OsdForce*ForceMult;
        _charControl.Move(_moveDir * Time.deltaTime);
        //if(!_fDetect || !_rDetect || !_lDetect) _wallContact = false;
    }

    void LedgeDectect(Ray ledgeRay, Ray bodyRay)
    {
        //Debug.Log("Ledge");
        if ((!Physics.Raycast(ledgeRay, 1.5f) && Physics.Raycast(bodyRay, 1.5f))&& !LedgeSpawned)
        {
            Debug.Log("Ledge Spawn");
            Instantiate(Ledge, (_charControl.transform.position - new Vector3(0,0.5f,0)), Quaternion.identity);
            LedgeSpawned = true;
        }
    }
    
    void Parcore()
    {
        if (_fDetect)
        {
            _moveDir.y = _climbVelocity - _climbDecay;
            _wallContact = true;
        }
        if (_lDetect)
        {
            _moveDir.y = _climbVelocity/2 - _climbDecay;

        }
        if (_rDetect)
        {
            _moveDir.y = _climbVelocity/2 -_climbDecay;
        }
    }

    //Fires Raycasts around the player at center and top of prefab.
    void ParcoreDetetion()
    {
        Vector3 mFwd = transform.TransformDirection(Vector3.forward); //Forword DIR
        Ray rMfRay = new Ray(transform.position, mFwd);
        Ray rHfRay = new Ray(transform.position + new Vector3(0, 1.5f, 0), mFwd);

        if (Physics.Raycast(rMfRay, 1)) _fDetect = true;
        if (!Physics.Raycast(rMfRay, 1)) _fDetect = false;

        Vector3 mLft = transform.TransformDirection(Vector3.left); //Left DIR
        Ray rMlRay = new Ray(transform.position, mLft);
        Ray rHlRay = new Ray(transform.position + new Vector3(0, 1.5f, 0), mLft);
        
        if (Physics.Raycast(rMlRay, 1)) _lDetect = true;
        if (!Physics.Raycast(rMlRay, 1)) _lDetect = false;

        Vector3 mRgt = transform.TransformDirection(Vector3.right); //Right DIR
        Ray rMrRay = new Ray(transform.position, mRgt);
        Ray rHrRay = new Ray(transform.position + new Vector3(0, 1.5f, 0), mRgt);
        
        if (Physics.Raycast(rMrRay, 1)) _rDetect = true;
        if (!Physics.Raycast(rMrRay, 1)) _rDetect = false;
    
        if(!_charControl.isGrounded) LedgeDectect(rHfRay, rMfRay);
        
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
    
    //Call this to Damage the Player;
    public void Damage(float value)
    {
        _health -= value;
        _healing = false;

    }

    IEnumerator Heal()
    {
        float temp = _health;
        //print("entered");
        yield return new WaitForSecondsRealtime(0.5f);
        //print(_health + " "+ temp);
        if (_health < temp)
        {
            //print("Damage continues no healing");
            _beingDamaged = true;
        }
        if (!_beingDamaged)
        {
            //print("HealTrigger Wait 3");
            yield return new WaitForSecondsRealtime(5);
            _healing = true;
        }
        _beingDamaged = false;
        yield break;
    }

    
    //Call this to push the player
    public void OutsideForce(Vector3 force)
    {
        //print(force);
        OsdForce = force;
        _charControl.Move(Vector3.Lerp(transform.position, force, 0.5f * Time.deltaTime));
    }

    public float GetHealth()
    {
        return _health;
    }
}