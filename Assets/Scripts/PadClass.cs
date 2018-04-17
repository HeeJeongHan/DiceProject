using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadClass : MonoBehaviour {

	private int columns;
	private int rows;
	public int numberOfFirstResource;
	public int numberOfSecondResource;

	private Vector3 padPosition;
	private TextMesh resourceUi;

	public GameObject textObject;
	//public GameObject[] testResourceList = new GameObject[2];

	public void UpdateText()
	{
		resourceUi = textObject.GetComponent<TextMesh> ();
		resourceUi.text = "";
		if (numberOfFirstResource != 0 && numberOfSecondResource != 0)
			resourceUi.text = "도토리 : " + numberOfFirstResource + "\n나뭇가지 : " + numberOfSecondResource;
		else if (numberOfFirstResource != 0 && numberOfSecondResource == 0)
			resourceUi.text = "도토리 : " + numberOfFirstResource;
		else if(numberOfFirstResource == 0 && numberOfSecondResource != 0)
			resourceUi.text = "나뭇가지 : " + numberOfSecondResource;
	}

	public void SetResourceOfPad(int fir, int sec)
	{
		numberOfFirstResource = fir;
		numberOfSecondResource = sec;
	}

	public void SetColRow(int col, int row){
		columns = col;
		rows = row;
	}

	public int GetColumn()
	{
		return columns;
	}

	public void SetPosition (){
		padPosition = new Vector3 (0f, 0f, 0f);
		padPosition.y = 1.3f * rows;
		if (columns == 0)
			padPosition.x = -1.9f;
		else if (columns == 1)
			padPosition.x = -0.6f;
		else if (columns == 2)
			padPosition.x = 0.6f;
		else if (columns == 3)
			padPosition.x = 1.9f;
		else {
			padPosition.x = 0;
			Debug.Log (rows + "Pad position is wrong");
		}
		transform.position = padPosition;
		
	}
}
