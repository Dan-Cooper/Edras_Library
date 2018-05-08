using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{

	public GameObject Player;
	
	public Text LargCardText;
	public Text SmallCardText0;
	public Text SmallCardText1;
	public Text SmallCardText2;
	public Text SmallCardText3;
	
	//Start Card Managementt
	public Image[] LargeCardImg;	//Load this with the images used in the UI
	public Image[] SmallCardImg0;	//Load this with the images used in the UI
	public Image[] SmallCardImg1;	//Load this with the images used in the UI
	public Image[] SmallCardImg2;	//Load this with the images used in the UI
	public Image[] SmallCardImg3;	//Load this with the images used in the UI

	private Queue<Image> LargeCardQ;		//Structure doing the heavy lifting
	private Queue<Image> SmallCardImg0Q;	//Structure doing the heavy lifting
	private Queue<Image> SmallCardImg1Q;	//Structure doing the heavy lifting
	private Queue<Image> SmallCardImg2Q;	//Structure doing the heavy lifting
	private Queue<Image> SmallCardImg3Q;	//Structure doing the heavy lifting

	private Image _curLarge;	//Call this for the setting of the image
	private Image _curSmall0;	//Call this for the setting of the image
	private Image _curSmall1;	//Call this for the setting of the image
	private Image _curSmall2;	//Call this for the setting of the image
	private Image _curSmall3;	//Call this for the setting of the image
	//END

	// Use this for initialization
	void Start () {
		LoadQ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Summon Plat"))
		{
			
		}
		
		if (Input.GetButtonDown("Switch Plat"))
		{
			LargeCardQ.Enqueue(_curSmall0);
			SmallCardImg0Q.Enqueue(_curSmall1);
			SmallCardImg1Q.Enqueue(_curSmall2);
			SmallCardImg2Q.Enqueue(_curSmall3);
			SmallCardImg3Q.Enqueue(_curLarge);

			_curLarge 	= LargeCardQ.Dequeue();
			_curSmall0 	= SmallCardImg0Q.Dequeue();
			_curSmall1 	= SmallCardImg1Q.Dequeue();
			_curSmall2 	= SmallCardImg2Q.Dequeue();
			_curSmall3 	= SmallCardImg3Q.Dequeue();

			if (true)	//DEBUG
			{
				print("Current Items : " + _curLarge.name + " : " + _curSmall0.name + " : " + _curSmall1.name + " : " + _curSmall2.name + " : " + _curSmall3.name);
				print("Next Items : " + LargeCardQ.Peek().name + " : " + SmallCardImg0Q.Peek().name + " : " + SmallCardImg1Q.Peek().name + " : " + SmallCardImg2Q.Peek().name + " : " + SmallCardImg3Q.Peek().name);
			}	
		}
		
		if (Input.GetButtonDown("Undo Summon"))
		{
			
		}
	}

	//Takes the arrays of Images and loades them into the aproprate Q
	void LoadQ()
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
	}

	void InitMaxPlat()
	{
		
	}
}
