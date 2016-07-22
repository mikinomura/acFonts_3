using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using MidiJack;

public class KnobIndicator : MonoBehaviour
{
	public int knobNumber;
	public int parameterNumber;
	float maxValue;
	float sliderValue;

	void Start()
	{
		sliderValue = gameObject.GetComponent<Slider>().value;
		maxValue = gameObject.GetComponent<Slider> ().maxValue;
	}

	void Update()
	{
		var channels = MidiMaster.GetKnobNumbers();
		var s = MidiMaster.GetKnob(knobNumber);
		knobNumber = channels [parameterNumber];
		print (s);
		print (sliderValue);
		gameObject.GetComponent<Slider>().value = s * maxValue;
	}
}