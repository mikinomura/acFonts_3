using UnityEngine;
using System.Collections;

namespace acFonts{
	public class MeshOnOff : MonoBehaviour {

		public GameObject MeshGroup;
		public GameObject FontsGroup;

		private bool sound;

		public void Start(){
			MeshGroup.SetActive (false);
			FontsGroup.SetActive (true);
			sound = true;
		}

		public void onClick(){

			if (MeshGroup.activeSelf) {
				MeshGroup.SetActive (false);
			} else {
				MeshGroup.SetActive (true);
			}

			if (FontsGroup.activeSelf) {
				FontsGroup.SetActive (false);
			} else {
				FontsGroup.SetActive (true);
			}
				
		}

		public void onClickSound(){
			ChangeAllChildValue target = FontsGroup.GetComponent<ChangeAllChildValue> ();
			ChangeAllChildValue meshTarget = MeshGroup.GetComponent<ChangeAllChildValue> ();

			if (sound) {
				meshTarget.soundEffect = false;
				target.soundEffect = false;
				sound = false;
			} else {
				meshTarget.soundEffect = true;
				target.soundEffect = true;
				sound = true;
			}
		}
	}
}