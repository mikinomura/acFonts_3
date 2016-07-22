using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace acFonts{
	public class MeshOnOff : MonoBehaviour {

		public GameObject MeshGroup;
		public GameObject FontsGroup;

		private bool sound;

		public void Start(){
			MeshGroup.SetActive (false);
			MeshGroup.GetComponent<ChangeAllChildValue> ().colorChange = false;
			FontsGroup.SetActive (true);
			FontsGroup.GetComponent<ChangeAllChildValue> ().colorChange = true;
			sound = false;
		}

		public void onClick(){

			if (MeshGroup.activeSelf) {
				MeshGroup.SetActive (false);
				MeshGroup.GetComponent<ChangeAllChildValue> ().colorChange = false;
			} else {
				MeshGroup.SetActive (true);
				MeshGroup.GetComponent<ChangeAllChildValue> ().colorChange = true;
				MeshGroup.GetComponent<ChangeAllChildValue> ().ChangeColor ();
			}

			if (FontsGroup.activeSelf) {
				FontsGroup.SetActive (false);
				FontsGroup.GetComponent<ChangeAllChildValue> ().colorChange = false;
			} else {
				FontsGroup.SetActive (true);
				FontsGroup.GetComponent<ChangeAllChildValue> ().colorChange = true;
				FontsGroup.GetComponent<ChangeAllChildValue> ().ChangeColor ();
			}
				
		}

		public void onClickSound(){
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
		}
	}
}