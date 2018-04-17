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

	private bool isDiceButtonOn = false;
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
		if (isDiceButtonOn)
			selectChar.text = "Select char!";
		/*void Update () 
{ 
if(Input.GetMouseButtonDown(0)) 
{ 
mousePos = Input.mousePosition; 
} 

if(Input.GetMouseButtonUp(0)) 
{ 
if(mousePos ==Input.mousePosition) 
{ 
    Ray ray = Camera.main.ScreenPointToRay(mousePos); 
  RaycastHit hit; 

  if(Physics.Raycast(ray, out hit, 100)) 
  { 
        Debug.Log(hit.collider.gameObject); 
Debug.DrawLine(ray.origin,ray.direction); 
hit.collider.gameObject.renderer.enabled =false; 

} 

} 


} 

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
		isDiceButtonOn = true;
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
