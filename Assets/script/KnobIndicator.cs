using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using MidiJack;

public class KnobIndicator : MonoBehaviour
{
	public int knobNumber;
	public int parameterNumber;
	public int noteNumber;
	float maxValue;
	float sliderValue;
	public bool IsKnob;
	public bool IsNote;
	public int parameter;
	public GameObject MeshGroup;
	public GameObject FontGroup;
	float lastNum;

	void Start()
	{
		if (gameObject.GetComponent<Slider> () != null) {
			sliderValue = gameObject.GetComponent<Slider> ().value;
			maxValue = gameObject.GetComponent<Slider> ().maxValue;
		}
	}

	void Update()
	{
		if (IsKnob) {
			var channels = MidiMaster.GetKnobNumbers ();
			var s = MidiMaster.GetKnob (knobNumber);
			//knobNumber = channels [parameterNumber];
			if (knobNumber == 19) {
				var difference = s * 100F - lastNum * 100F;
				//if (s != 0) {
					if (MeshGroup.activeSelf) {
						MeshGroup.GetComponent<acFonts.ChangeAllChildValue> ().ShowAircord (difference);

					} else if (FontGroup.activeSelf) {
						FontGroup.GetComponent<acFonts.ChangeAllChildValue> ().ShowAircord (difference);
					}
				//} else {
				/*
					if (MeshGroup.activeSelf) {
						MeshGroup.GetComponent<acFonts.ChangeAllChildValue> ().ShowAircord (s);

					} else if (FontGroup.activeSelf) {
						FontGroup.GetComponent<acFonts.ChangeAllChildValue> ().ShowAircord (s);
					}
					*/
				//}

			} else {
				gameObject.GetComponent<Slider> ().value = s * maxValue;
			}

			lastNum = s;
		}
		if (IsNote) {
			if(MidiMaster.GetKeyDown(noteNumber))
			{
				if (noteNumber != 65 && noteNumber != 64) {
					if (gameObject.GetComponent<Slider> ().value == maxValue) {
						gameObject.GetComponent<Slider> ().value = 0;
					} else {
						gameObject.GetComponent<Slider> ().value = maxValue;
					}
				} else if (noteNumber == 65) {
					/*
					if (MeshGroup.activeSelf) {
						MeshGroup.GetComponent<acFonts.ChangeAllChildValue> ().ShowAircord ();

					} else if (FontGroup.activeSelf) {
						FontGroup.GetComponent<acFonts.ChangeAllChildValue> ().ShowAircord ();
					}
					*/


				} else if (noteNumber == 64) {
					/*
					if (MeshGroup.activeSelf) {
						MeshGroup.GetComponent<acFonts.ChangeAllChildValue> ().Bigger ();
						if (MeshGroup.GetComponent<acFonts.ChangeAllChildValue> ().mode == acFonts.ChangeAllChildValue.MODE.AIRCORD) {
							MeshGroup.GetComponent<acFonts.ChangeAllChildValue> ().mode = acFonts.ChangeAllChildValue.MODE.ALL;
						} else {
							MeshGroup.GetComponent<acFonts.ChangeAllChildValue> ().mode = acFonts.ChangeAllChildValue.MODE.AIRCORD;
						}
					} else if (FontGroup.activeSelf) {
						if (FontGroup.GetComponent<acFonts.ChangeAllChildValue> ().mode == acFonts.ChangeAllChildValue.MODE.AIRCORD) {
							FontGroup.GetComponent<acFonts.ChangeAllChildValue> ().mode = acFonts.ChangeAllChildValue.MODE.ALL;
						}else {
							FontGroup.GetComponent<acFonts.ChangeAllChildValue> ().mode = acFonts.ChangeAllChildValue.MODE.AIRCORD;
						}

						FontGroup.GetComponent<acFonts.ChangeAllChildValue> ().Bigger ();
					}
					*/
				}
			}
		
		}

	}
}