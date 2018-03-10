using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	RaycastHit raycastTap;
	[SerializeField]
	private AudioSource _clickEffect;
	[SerializeField]
	private GameObject _soundOn;
	[SerializeField]
	private GameObject _soundOff;


	// Use this for initialization
	void Start () {

		_soundOn.SetActive(true);
		_soundOff.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {

		TapInput ();

	}

	//----------------------------------------------------------------------------------------------------

	public void TapInput () {

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); 
			if (Physics.Raycast(ray, out raycastTap)) 
			{
				if (raycastTap.collider.tag == "SoundON") 
				{
					_clickEffect.volume = 0;
					_soundOn.SetActive(false);
					_soundOff.SetActive(true);
				}

				if (raycastTap.collider.tag == "SoundOFF") 
				{
					_clickEffect.volume = 0.8f;
					_soundOn.SetActive(true);
					_soundOff.SetActive(false);
					_clickEffect.Play ();
				}

				if (raycastTap.collider.tag == "StartGame") 
				{
					_clickEffect.Play ();
					SceneManager.LoadScene("_MainLoad");
				}
			}
		}

	}
}
