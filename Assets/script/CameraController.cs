using UnityEngine;
using System.Collections;
using MidiJack;

namespace acFonts{

public class CameraController : MonoBehaviour {
		
		public int knobNumber;
		Vector3 center;
		int _countToUpdate;
		int _lastMessageCount;

		public enum MOVESTATUS
		{
			MOVE,
			STOP
		}

		public MOVESTATUS moveStatus;

	// Use this for initialization
	void Start () {
			center = new Vector3 (840,0,0);
			knobNumber = 24;
			moveStatus = MOVESTATUS.MOVE;
			_lastMessageCount = 0;
	}
	
	// Update is called once per frame
	void Update () {

			/*
			var mcount = MidiDriver.Instance.TotalMessageCount;
			if (mcount != _lastMessageCount) {
				moveStatus = MOVESTATUS.MOVE;
				_lastMessageCount = mcount;
			} else {
				moveStatus = MOVESTATUS.STOP;
			}
			*/

			var channels = MidiMaster.GetKnobNumbers ();
			var s = MidiMaster.GetKnob (knobNumber);


			if (moveStatus == MOVESTATUS.MOVE) {
				if (s == 1F) {
					//For testing. It should be controled by MIDI Controller
					transform.RotateAround (center, Vector3.right, s * 50F * Time.deltaTime);
				} else {
					//transform.RotateAround (center, Vector3.right, -50F * Time.deltaTime);
				}
			}

	}
}


}
