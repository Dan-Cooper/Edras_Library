using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private CharacterController _charControl;
    //private Rigidbody rb;

    public GameObject Ledge;
    public bool LedgeSpawned;

    public float WalkSpeed;
    private bool _sprintRequest;

    [Range(1, 10)] public float JumpVelocity;

    public float Gravity;

    public float FallMultiplier;
    public float LowJumpMultiplier;

    private bool _jumpRequest;
    private Vector3 _moveDir = new Vector3(0,0,0);


    private bool _fDetect;
    private bool _lDetect;
    private bool _rDetect;
    private bool _wallContact;

   [SerializeField] private float _climbVelocity;
   [SerializeField] private float _climbDecay;

    // Use this for initialization
    void Awake()
    {
        _charControl = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))  LedgeSpawned = false;
        ParcoreDetetion();

        if (Input.GetButtonDown("Jump") && _charControl.isGrounded) _jumpRequest = true;
        if (Input.GetButtonDown("Run")) WalkSpeed *= 2;
        if (Input.GetButtonUp("Run")) WalkSpeed /= 2;
        if ((_fDetect || _rDetect || _lDetect) && !_charControl.isGrounded)  //To Slow rait of climb as climb progresses.
        {
            _climbDecay += Mathf.Lerp(0,8,(Time.deltaTime / 1f));
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
        if (_charControl.isGrounded || (_wallContact ))
        {
            //Debug.Log("Jump" + jumpRequest);
            _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDir = transform.TransformDirection(_moveDir);
            _moveDir *= WalkSpeed;
            if (_jumpRequest)
            {
                _moveDir.y = JumpVelocity;
                _jumpRequest = false;
            }
            _fDetect = false;
            _lDetect = false;
            _rDetect = false;
            
            _climbDecay = 0;
        }
        
        Parcore();
        
        if (_moveDir.y < 0.2)
        {
            _moveDir += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
            //Debug.Log("Long" + _fDetect);
        }
        else if (_moveDir.y > 0.2 && !Input.GetButton("Jump"))
        {
            _moveDir += Vector3.up * Physics.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
            //Debug.Log("short"+ _fDetect);
        }
        //Debug.Log("Move" + moveDir.y);
        _moveDir.y -= Gravity * Time.deltaTime;
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
        else if(!_fDetect)
        {
            _wallContact = false;
        }
        if (_lDetect)
        {
            _moveDir.y = _climbVelocity/2 - _climbDecay;
            _wallContact = true;
        }
        else if(!_lDetect)
        {
            _wallContact = false;
        }
        if (_rDetect)
        {
            _moveDir.y = _climbVelocity/2 -_climbDecay;
            _wallContact = true;
        }
        else if(!_rDetect)
        {
            _wallContact = false;
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
}