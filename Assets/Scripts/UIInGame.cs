using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{

	public GameObject Player;

	public Image FadeOut;

	public Image[] AllCards; // Call this to change the images
	[Space]
	public Text LargeCardText;
	public Text SmallCardText0;
	public Text SmallCardText1;
	public Text SmallCardText2;
	public Text SmallCardText3;
	public Text SmallCardText4;
	[Space]
	//Start Card Managementt
	public Sprite[] LargeCardImg;	//Load this with the images used in the UI
	public Sprite[] SmallCardImg0;	//Load this with the images used in the UI
	public Sprite[] SmallCardImg1;	//Load this with the images used in the UI
	public Sprite[] SmallCardImg2;	//Load this with the images used in the UI
	public Sprite[] SmallCardImg3;	//Load this with the images used in the UI
	public Sprite[] SmallCardImg4;	//Load this with the images used in the UI
	[Space]
	private Queue<Sprite> LargeCardQ;		//Structure doing the heavy lifting
	private Queue<Sprite> SmallCardImg0Q;	//Structure doing the heavy lifting
	private Queue<Sprite> SmallCardImg1Q;	//Structure doing the heavy lifting
	private Queue<Sprite> SmallCardImg2Q;	//Structure doing the heavy lifting
	private Queue<Sprite> SmallCardImg3Q;	//Structure doing the heavy lifting
	private Queue<Sprite> SmallCardImg4Q;	//Structure doing the heavy lifting
	[Space]
	private Sprite _curLarge;	//Call this for the setting of the image
	private Sprite _curSmall0;	//Call this for the setting of the image
	private Sprite _curSmall1;	//Call this for the setting of the image
	private Sprite _curSmall2;	//Call this for the setting of the image
	private Sprite _curSmall3;	//Call this for the setting of the image
	private Sprite _curSmall4;	//Call this for the setting of the image
	//END

	// Use this for initialization
	void Start () 
	{
		LargeCardQ	  = new Queue<Sprite>();
		SmallCardImg0Q= new Queue<Sprite>();
		SmallCardImg1Q= new Queue<Sprite>();
		SmallCardImg2Q= new Queue<Sprite>();
		SmallCardImg3Q= new Queue<Sprite>();
		SmallCardImg4Q= new Queue<Sprite>();

		
		StartCoroutine(LoadQ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		LargeCardText.text =""+ Player.GetComponent<RampSpawning>().Get_CurentVal();
		
		if (Input.GetButtonDown("Summon Plat"))
		{
			
		}
		
		if (Input.GetButtonDown("Switch Plat"))
		{
			LargeCardQ.Enqueue(_curSmall0);
			SmallCardImg0Q.Enqueue(_curSmall1);
			SmallCardImg1Q.Enqueue(_curSmall2);
			SmallCardImg2Q.Enqueue(_curSmall3);
			SmallCardImg3Q.Enqueue(_curSmall4);
			SmallCardImg4Q.Enqueue(_curLarge);

			_curLarge 	= LargeCardQ.Dequeue();
			_curSmall0 	= SmallCardImg0Q.Dequeue();
			_curSmall1 	= SmallCardImg1Q.Dequeue();
			_curSmall2 	= SmallCardImg2Q.Dequeue();
			_curSmall3 	= SmallCardImg3Q.Dequeue();
			_curSmall4 	= SmallCardImg4Q.Dequeue();

			AllCards[0].sprite = _curSmall0;
			AllCards[1].sprite = _curSmall1;
			AllCards[2].sprite = _curSmall2;
			AllCards[3].sprite = _curSmall3;
			AllCards[4].sprite = _curSmall4;
			AllCards[5].sprite = _curLarge;

			//LargeCardText.text = SmallCardText0.text;
			SmallCardText0.text = SmallCardText1.text;
			SmallCardText1.text = SmallCardText2.text;
			SmallCardText2.text = SmallCardText3.text;
			SmallCardText3.text = SmallCardText4.text;
			SmallCardText4.text = LargeCardText.text;

			if (true)	//DEBUG
			{
				//print("Current Items : " + _curLarge.name + " : " + _curSmall0.name + " : " + _curSmall1.name + " : " + _curSmall2.name + " : " + _curSmall3.name+ " : " + _curSmall4.name);
				//print("Next Items : " + LargeCardQ.Peek().name + " : " + SmallCardImg0Q.Peek().name + " : " + SmallCardImg1Q.Peek().name + " : " + SmallCardImg2Q.Peek().name + " : " + SmallCardImg3Q.Peek().name + " : " + SmallCardImg4Q.Peek().name);
			}	
		}
		
		if (Input.GetButtonDown("Undo Summon"))
		{
			
		}
	}

	//Takes the arrays of Images and loades them into the aproprate Q
	IEnumerator LoadQ()
	{
		foreach (var Image in LargeCardImg)
		{
			LargeCardQ.Enqueue(Image);
		}
		foreach (var Image in SmallCardImg0)
		{
			SmallCardImg0Q.Enqueue(Image);
		}
		foreach (var Image in SmallCardImg1)
		{
			SmallCardImg1Q.Enqueue(Image);
		}
		foreach (var Image in SmallCardImg2)
		{
			SmallCardImg2Q.Enqueue(Image);
		}
		foreach (var Image in SmallCardImg3)
		{
			SmallCardImg3Q.Enqueue(Image);
		}
		foreach (var Image in SmallCardImg4)
		{
			SmallCardImg4Q.Enqueue(Image);
		}
		print("UI Load True");

		int[] InitArray  = Player.GetComponent<RampSpawning>().Get_List().ToArray();

		LargeCardText.text 	= "" + Player.GetComponent<RampSpawning>().Get_CurentVal();
		SmallCardText0.text = "" + InitArray[0];
		SmallCardText1.text = "" + InitArray[1];
		SmallCardText2.text = "" + InitArray[2];
		SmallCardText3.text = "" + InitArray[3];
		SmallCardText4.text = "" + InitArray[4];
		yield break;
	}
}
