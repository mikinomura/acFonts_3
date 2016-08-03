using UnityEngine;
using System.Collections;
using MidiJack;

namespace acFonts{
	public class aController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
			aMove ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void aMove()
		{
			iTween.RotateTo (gameObject, iTween.Hash(
				"x", -85F,
				"y", 175F,
				"z",5F,
				"time", 1F,
				"loopType", "pingPong"
			));

		}
}
}

