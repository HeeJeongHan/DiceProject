using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public GameObject StartGamePannel;

	public void SelectMapButton()
	{
		StartGamePannel.SetActive (true);
	}

	public void CloseStartPopup()
	{
		StartGamePannel.SetActive (false);
	}
}
