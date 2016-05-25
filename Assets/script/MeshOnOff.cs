using UnityEngine;
using System.Collections;

namespace acFonts{
	public class MeshOnOff : MonoBehaviour {

		public GameObject MeshGroup;
		public GameObject FontsGroup;

		public void Start(){
			MeshGroup.SetActive (false);
			FontsGroup.SetActive (true);
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
	}
}