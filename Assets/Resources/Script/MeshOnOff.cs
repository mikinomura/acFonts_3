using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MidiJack;

namespace acFonts{
	public class MeshOnOff : MonoBehaviour {

		public GameObject MeshGroup;
		public GameObject FontsGroup;
		//For Midi Controller
		public int noteNumber;
		public GameObject camera;
		private bool sound;

		public void Start(){
			MeshGroup.GetComponent<ChangeAllChildValue> ().colorChange = false;
			MeshGroup.SetActive (false);
			FontsGroup.SetActive (true);
			FontsGroup.GetComponent<ChangeAllChildValue> ().colorChange = true;
			sound = false;
		}

		void Update()
		{
			Cursor.visible = false;
			if (MidiMaster.GetKeyDown (63)) {
				//onClick ();
			} else if (MidiMaster.GetKeyDown (61)) {
				
				if (camera.GetComponent<CameraController> ().moveStatus == CameraController.MOVESTATUS.STOP) {
					camera.GetComponent<CameraController> ().moveStatus = CameraController.MOVESTATUS.MOVE;
				} else {
					camera.GetComponent<CameraController> ().moveStatus = CameraController.MOVESTATUS.STOP;
				}
					
			} else if(MidiMaster.GetKeyDown(62))
			{
				onClickColor ();
			}
				
		}

		public void onClickColor(){
			/*
			if (MeshGroup.activeSelf) {
				MeshGroup.GetComponent<ChangeAllChildValue> ().ChangeColor ();
			}
			if (FontsGroup.activeSelf) {
				FontsGroup.GetComponent<ChangeAllChildValue> ().ChangeColor ();
			}*/
		
		}

		public void onClick(){
			/*
			if (MeshGroup.activeSelf) {
				//MeshGroup.GetComponent<ChangeAllChildValue> ().colorChange = false;
				MeshGroup.SetActive (false);
			} else {
				MeshGroup.SetActive (true);
				//MeshGroup.GetComponent<ChangeAllChildValue> ().colorChange = true;
				//MeshGroup.GetComponent<ChangeAllChildValue> ().ChangeColor ();
			}

			if (FontsGroup.activeSelf) {
				FontsGroup.GetComponent<ChangeAllChildValue> ().colorChange = false;
				FontsGroup.SetActive (false);

			} else {
				FontsGroup.SetActive (true);
				FontsGroup.GetComponent<ChangeAllChildValue> ().colorChange = true;
				FontsGroup.GetComponent<ChangeAllChildValue> ().ChangeColor ();
			}*/
				
		}

		public void onClickSound(){
			/*
			ChangeAllChildValue target = FontsGroup.GetComponent<ChangeAllChildValue> ();
			ChangeAllChildValue meshTarget = MeshGroup.GetComponent<ChangeAllChildValue> ();

			if (sound) {
				meshTarget.soundEffect = false;
				target.soundEffect = false;
				sound = false;
				meshTarget.ChangeParameter (3);
				meshTarget.ChangeParameter (4);
				GameObject.Find ("Value 3 Slider").GetComponent<Slider> ().interactable = true;
				GameObject.Find ("Value 4 Slider").GetComponent<Slider> ().interactable = true;
				target.ChangeParameter (4);
				target.ChangeParameter (4);
			} else {
				meshTarget.soundEffect = true;
				target.soundEffect = true;
				sound = true;
				GameObject.Find ("Value 3 Slider").GetComponent<Slider> ().interactable = false;
				GameObject.Find ("Value 4 Slider").GetComponent<Slider> ().interactable = false;
			}
			*/
		}
	}
}