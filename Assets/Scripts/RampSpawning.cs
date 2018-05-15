// This is Cathy's baby.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSpawning : MonoBehaviour
{
    public float MinDistance = 3f;
    public float MaxDistance = 15f;
    [Space] [Header("Magic Platform Limits:")] public bool EnableMaxByType = true;
    
    public int SquarePlat;
    public int IPlat;
    public int LPlat;
    public int RampPlat;
    public int XPlat;
    public int WallPlat;

    [Space] [Header("Size should be the same integars.")] public GameObject[] ramp;
    public GameObject[] RampGuideObj;

    private Queue<GameObject> rampQ;
    private Queue<GameObject> rampGuideObjQ;
    [Space] public Transform whereRampSpawns; // Why 2 transforms?
    private Transform playerTransform; // Why 2 transforms?
    private GameObject guideInst;
    [Space] public bool RampEnable;
    private bool _prepareRamp;

    private Queue<int> _list;

    private int _curPlatVal;

    private int _squarePlat;
    private int _iPlat;
    private int _lPlat;
    private int _rampPlat;
    private int _xPlat;
    private int _wallPlat;


    void Start()
    {
        _list = new Queue<int>();
        rampQ = new Queue<GameObject>();
        rampGuideObjQ = new Queue<GameObject>();
        playerTransform = GetComponent<Transform>();
        _prepareRamp = false;
        StartCoroutine(LoadQ());
    }

    void Update()
    {
        if (RampEnable)
        {
            // Inputs: "Summon Plat", "Switch Plat", "Mouse ScrollWheel", ""
            if (Input.GetButtonDown("Summon Plat"))
            {
                if (_prepareRamp)
                {
                    if (_list.Peek() > 0)
                        //( (currentRampTotal < maxTotal) &&(currentRampByType[rampTag] < maxByType[rampTag]) ) 
                    {
                        SummonPlatMethod();
                    }
                    else
                    {
                        Debug.Log("Can't place any more! :(");
                    }
                }
                else if (!_prepareRamp)
                {
                    SummonGuideMethod();
                }
                else
                {
                    Debug.Log("CN: Some ramp spawning error.");
                }
            }
            SwitchPlatMethod();

            if (_prepareRamp)
            {
                ScrollPlatMethod();

                if (Input.GetButtonDown("Undo Summon"))
                {
                    Destroy(guideInst);
                    _prepareRamp = false;
                }
            }
        }
        else
        {
            //	When disabled
            Debug.Log("CN: Ramp spawning disabled. :3");
        }
    }
    //####################################################################

    void SummonPlatMethod()
    {
        Destroy(guideInst); // deletes rampGuide instance

        Instantiate(rampQ.Peek()
            , guideInst.transform.position
            , playerTransform.rotation
        );
        // Ctrl + F add sound here
        _curPlatVal -= 1;
        _prepareRamp = false;
    }

    void SummonGuideMethod()
    {
        guideInst =
            Instantiate(rampGuideObjQ.Peek()
                , whereRampSpawns.position
                , playerTransform.rotation
                , playerTransform
                //							, whereRampSpawns
            );
        // Ctrl + F add sound here

        _prepareRamp = true;
    }
    //####################################################################

    void SwitchPlatMethod()
    {
        if (Input.GetButtonDown("Switch Plat"))
        {
            // assign ramp# based on rampTag
            /*if(rampTag>=0 && rampTag < arraySize-1){
                rampTag +=1;
            }
            else if(rampTag == arraySize-1){
                rampTag = 0;
            }
            else{
                Debug.Log("Error.");
            }*/

            // vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv testing grounds
            Debug.Log(rampQ.Peek().name + "==" + _list.Peek() + "?");
            /*if(currentRampByType[rampTag] == maxByType[rampTag]) {	// skip if that plat all used
                if(rampTag>=0 || rampTag < arraySize-1){		// repeat code
                    rampTag +=1;
                }
                else if(rampTag == arraySize-1){
                    rampTag = 0;
                }
                else{
                    Debug.Log("Hullo.");
                }
                Debug.Log("xxhcjxhjgkl");

            }*/

            GameObject hold = rampQ.Dequeue();
            rampQ.Enqueue(hold);
            GameObject h2 = rampGuideObjQ.Dequeue();
            rampGuideObjQ.Enqueue(h2);
            _list.Enqueue(_curPlatVal);
            _curPlatVal = _list.Dequeue();
            
            // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ testing grounds

            if (_prepareRamp)
            {
                Destroy(guideInst);
                guideInst =
                    Instantiate(rampGuideObjQ.Peek()
                        , whereRampSpawns.position
                        , playerTransform.rotation
                        , playerTransform
                        //							,whereRampSpawns
                    );
                // Ctrl + F add sound here
            }
        }
    }
    //####################################################################

    void ScrollPlatMethod()
    {
        //Debug.Log(guideInst.transform.localPosition.y);

        guideInst.transform.localPosition += new Vector3(0f, 0f, // scrolling thing
            Input.GetAxis("Mouse ScrollWheel") * 10f);

        if (guideInst.transform.localPosition.z <= MinDistance)
        {
            // minimum distance from player
            guideInst.transform.localPosition =
                new Vector3(0f, whereRampSpawns.position.y, MinDistance);
        }
        if (guideInst.transform.localPosition.z >= MaxDistance)
        {
            // maximum distance from player
            guideInst.transform.localPosition =
                new Vector3(0f, whereRampSpawns.position.y, MaxDistance);
        }
    }
    //####################################################################

    IEnumerator LoadQ()
    {
        _list.Enqueue(SquarePlat);
        _list.Enqueue(IPlat);
        _list.Enqueue(LPlat);
        _list.Enqueue(RampPlat);
        _list.Enqueue(XPlat);
        _list.Enqueue(WallPlat);
        

        _curPlatVal = _list.Dequeue();
        
        print("_List loaded if not 0 or null: "+_list.Count);

        foreach (GameObject go in ramp)
        {
            rampQ.Enqueue(go);
        }
        print("Ramps Loaded if not 0 or null: "+ rampQ.Count);
        foreach (GameObject rgo in RampGuideObj)
        {
            rampGuideObjQ.Enqueue(rgo);
        }
        print("RampGuides Loaded if not 0 or null: "+ rampGuideObjQ.Count);
        yield break;
    }
}