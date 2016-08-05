using UnityEngine;
using System.Collections;
using MidiJack;
using System.Runtime.InteropServices;

namespace acFonts{

public class CameraController : MonoBehaviour {
		
		public int knobNumber;
		Vector3 center;
		int _countToUpdate;
		int lastMessageCount;
		float speed;

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
			lastMessageCount = 0;
			speed = 0;
	}
	
	// Update is called once per frame
	void Update () {


			/*
			var mcount = MidiDriver.Instance.TotalMessageCount;
			var mHistory = MidiDriver.Instance.History;
			if (mcount != lastMessageCount) {
				moveStatus = MOVESTATUS.MOVE;
				//_lastMessageCount = mcount;
			} else {
				moveStatus = MOVESTATUS.STOP;
			}
			*/

			var channels = MidiMaster.GetKnobNumbers ();
			var s = MidiMaster.GetKnob (knobNumber);


			if (moveStatus == MOVESTATUS.MOVE) {
				if (s == 1F) {
					gameObject.GetComponent<Animator> ().SetFloat ("speed", 1f);
					gameObject.GetComponent<Animator> ().SetTrigger ("IsCameraMove");
					//speed = 1F;
				} else {
					gameObject.GetComponent<Animator> ().SetFloat ("speed", 0F);
					//speed = -1F;
				}
			} else {
				gameObject.GetComponent<Animator> ().SetFloat ("speed",0F);
			}

			if (MidiMaster.GetKeyDown (66)) {
				gameObject.GetComponent<Kino.AnalogGlitch> ().scanLineJitter = 0.26F;
			}
			if(MidiMaster.GetKeyUp(66)){
				gameObject.GetComponent<Kino.AnalogGlitch> ().scanLineJitter = 0F;
			}

			if (MidiMaster.GetKeyDown (61)) {
				gameObject.GetComponent<Kino.AnalogGlitch> ().horizontalShake = 0.15F;
			}
			if(MidiMaster.GetKeyUp(61)){
				gameObject.GetComponent<Kino.AnalogGlitch> ().horizontalShake = 0F;
			}

			if (MidiMaster.GetKeyDown (67)) {
				gameObject.GetComponent<Kino.AnalogGlitch> ().colorDrift = 0.35F;
			}

			if (MidiMaster.GetKeyUp (67)) {
				gameObject.GetComponent<Kino.AnalogGlitch> ().colorDrift = 0F;
			}
	}
}


}
