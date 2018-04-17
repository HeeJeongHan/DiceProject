using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

	public GameObject backgroundSprite;
	public GameObject padSprite;

	private int sumOfFirstResource = 0;
	private int sumOfSecondResource = 0;
	private int level;
	private int backgroundCode;
	private Transform boardHolder;
	private PadClass[] padClassArray;
	private GameObject[] padObject;


	public void SetupScene(int lev, int back)
	{
		level = lev;
		backgroundCode = back;

		BackgroundSetup ();
		InitalisePad ();
		NumberOfResourceByRandom ();
	}

	void BackgroundSetup()//가장 뒷 배경 그리기
	{
		boardHolder = new GameObject ("Board").transform;

		int numberOfSprite;
		if (level == 0)
			numberOfSprite = 3;
		else if (level == 1)
			numberOfSprite = 5;
		else if (level == 2)
			numberOfSprite = 6;
		else {
			numberOfSprite = 1;
			Debug.Log ("BackgroundSetup Function's level input is wrong");
		}
		
		for (int x = 0; x < numberOfSprite; x++) {
			GameObject instance = Instantiate (backgroundSprite, new Vector3 (0f, 3 + 10.14f * x, 0f), Quaternion.identity);
			instance.transform.SetParent (boardHolder);
		}
	}

	int RowsByLevel()//레벨을 가로줄로 변환
	{
		if (level == 0)
			return 20;
		else if (level == 1)
			return 30;
		else if (level == 2)
			return 40;
		else
			return 1;
	}

	void InitalisePad()//빈 오브젝트 만들기>padSprite를 instantiate>padSprite의 padclass를 getcomponent>Set Position
	{		
		padObject = new GameObject[RowsByLevel ()];
		padClassArray = new PadClass[RowsByLevel ()];

		int plusMinus = 1;

		for (int x = 0; x < RowsByLevel(); x++) {
			padObject [x] = Instantiate (padSprite, new Vector3(0f,0f,0f), Quaternion.identity);
			padObject [x].transform.SetParent (boardHolder);
		}
		for (int x = 0; x < RowsByLevel (); x++) {
			
			padClassArray [x] = padObject [x].GetComponent<PadClass> ();

			if (x == 0) {
				padClassArray [x].SetColRow (Random.Range (0, 3), x);

			} else {
				if (padClassArray [x - 1].GetColumn () == 3) {
					plusMinus = -1;
				} else if (padClassArray [x - 1].GetColumn () == 0) {
					plusMinus = 1;
				}
				padClassArray [x].SetColRow (padClassArray [x - 1].GetColumn () + plusMinus, x);
			}
			padClassArray [x].SetPosition ();
		}
	}

	void NumberOfResourceByRandom()
	{
		for (int x = 0; x < RowsByLevel(); x++) {
			int numberOfResourceOnPad = Random.Range (0, 2);
			int numberOfFirstResource = Random.Range (1, 4);
			int numberOfSecondResource = Random.Range (1, 4);

			if (numberOfResourceOnPad == 0)
				padClassArray [x].SetResourceOfPad (numberOfFirstResource, numberOfSecondResource);
			else if (numberOfResourceOnPad == 1)
				padClassArray [x].SetResourceOfPad (numberOfFirstResource, 0);
			else if (numberOfResourceOnPad == 2)
				padClassArray [x].SetResourceOfPad (0, numberOfSecondResource);
			padClassArray [x].UpdateText ();
			sumOfFirstResource += numberOfFirstResource;
			sumOfSecondResource += numberOfSecondResource;
		}
	}
	public int GetSumOfFirstResouce()
	{
		return sumOfFirstResource;
	}
	public int GetSumOfSecondResouce()
	{
		return sumOfSecondResource;
	}
}
