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

	void Start()
	{
		sliderValue = gameObject.GetComponent<Slider>().value;
		maxValue = gameObject.GetComponent<Slider> ().maxValue;

	}

	void Update()
	{
		if (IsKnob) {
			var channels = MidiMaster.GetKnobNumbers ();
			var s = MidiMaster.GetKnob (knobNumber);
			//knobNumber = channels [parameterNumber];
			gameObject.GetComponent<Slider> ().value = s * maxValue;
		}
		if (IsNote) {
			if(MidiMaster.GetKeyDown(noteNumber))
			{
				if (gameObject.GetComponent<Slider> ().value == maxValue) {
					gameObject.GetComponent<Slider> ().value = 0;
				} else {
					gameObject.GetComponent<Slider> ().value = maxValue;
				}
			}
		
		}

	}
}