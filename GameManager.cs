using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public int level;
	public int backgroundCode;
	public GameObject animalChar;//*********************************
	public static GameManager instance = null;
	public Text goalText;
	public Button diceButton;
	public Text textInDice;
	public Text selectChar;

	private float power = 0.5f;
	private int diceResult = 0;
	private int haveFirstResource;
	private int haveSecondResource;
	private int goalOfFirstResource;
	private int goalOfSecondResource;
	private BoardManager boardScript;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();
		haveFirstResource = 0;
		haveSecondResource = 0;
		InitGame ();
	}

	void Update(){




		/*
		if (diceResult != 0) {
			selectChar.text = "select char!";
		}
		if (Input.GetMouseButtonUp(0)) {
			Debug.Log ("hello!");
			diceResult = 0;
			selectChar.text = "";
		}*/
	} 

	void InitGame()
	{
		boardScript.SetupScene (level, backgroundCode);
		Instantiate (animalChar,new Vector3(2.2f,0.1f,0f), Quaternion.identity);//*********************************
		SetGoalResource ();
		UpdateUi ();
	}

	void SetGoalResource()
	{
		goalOfFirstResource = (int)(boardScript.GetSumOfFirstResouce () * power);
		goalOfSecondResource = (int)(boardScript.GetSumOfSecondResouce () * power);
	}
		
	void UpdateUi()
	{
		goalText.text = "도토리 : " + haveFirstResource + " / " + goalOfFirstResource + "\n나뭇가지 : " + haveSecondResource + " / " + goalOfSecondResource; 
	}

	public void ClickDice()
	{
		diceResult = Random.Range (1, 6);
		textInDice.text = "주사위값\n" + diceResult;
	}

	GameObject GetClickedObject()
	{
		RaycastHit hit;
		GameObject target = null;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray.origin, ray.direction, out hit))
		{
			target = hit.collider.gameObject;
		}
		return target;
	}
}
