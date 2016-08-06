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
		Vector3 defaultPos;
		Quaternion defaultRotate;

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
			moveStatus = MOVESTATUS.STOP;
			lastMessageCount = 0;
			speed = 0;
			defaultPos = gameObject.transform.position;
			defaultRotate = gameObject.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {


	}
		public void CameraMove(float s){
			var z = gameObject.transform.position.z;
			if (s == 127F) {
				if (z < -331F) {
					gameObject.transform.position += new Vector3 (0, 0F, 5f);
					if (z > -1200F && z < -1080F) {
						gameObject.transform.Rotate (0, -1, 0);
					}

					if (z > -756F && z < -656F) {
						gameObject.transform.Rotate (-1, 0, 0);
					}
				} 
			} else {
					gameObject.transform.position += new Vector3 (0,0,-5F);
					if(gameObject.transform.position.z > -1200F && gameObject.transform.position.z < -1080F){
						gameObject.transform.Rotate(0,1,0);
					}

					if(z > -756F && z < -656F){
						gameObject.transform.Rotate(1,0,0);
					}

			}
		}

		public void SetToDefault(){
			gameObject.transform.position = defaultPos;
			gameObject.transform.localRotation = defaultRotate;
		}

		public void Move(){
			iTween.RotateTo (gameObject, iTween.Hash(
				"z", -5F,
				"time",0.2F
			));

			iTween.RotateTo(gameObject, iTween.Hash(
				"z", 0F,
				"time",0.2f,
				"delay",0.3F,
				"easeType","easeOutBounce"
			)
			);
		}
}


}
