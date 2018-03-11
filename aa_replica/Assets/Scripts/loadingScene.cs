using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingScene : MonoBehaviour {

	[SerializeField]
	private int _loadingCount;
	[SerializeField]
	private Text _loadingText;
	private bool _loadingOn = true;

	// Use this for initialization
	void Start () {

		_loadingCount = 0;

	}
	
	// Update is called once per frame
	void Update () {

		StartGame ();

		if (_loadingOn == true) { 
			Loading ();
		}

	}

	void Loading () {
		
		_loadingCount++;
		_loadingText.text = _loadingCount + "%";

	}

	void StartGame () {
		if (_loadingCount == 100) {
			_loadingOn = false;
			SceneManager.LoadScene ("_MainGame");
		}
	}

}
