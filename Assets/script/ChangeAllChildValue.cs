using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;


namespace acFonts{
	[RequireComponent(typeof(AudioSource))]
	public class ChangeAllChildValue : MonoBehaviour {

		private Renderer[] renderers;

		private float value1;
		private float value2;
		private float value3;
		private float value4;
		private float value5;
		private float value6;
		public Color color;
		private GameObject Value1SliderGet;
		private GameObject Value2SliderGet;
		private GameObject Value3SliderGet;
		private GameObject Value4SliderGet;
		private GameObject Value5SliderGet;
		private GameObject Value6SliderGet;
		private Color randomColorX;
		private Color randomColorY;

		public Slider value1Slider;
		public Slider value2Slider;
		public Slider value3Slider;
		public Slider value4Slider;
		public Slider value5Slider;
		public Slider value6Slider;
		public Button colorBottun;
		public Button meshBottun;

		//for sound
		private AudioSource audio;
		float[] waveData_ = new float[1024];

		// Use this for initialization
		void Start () {
			renderers = GetComponentsInChildren<Renderer>();
			//Adds a listener to the main slider and invokes a method when the value changes.
			ChangeColor();

			value1Slider.onValueChanged.AddListener (delegate {ChangeParameter ();});
			value2Slider.onValueChanged.AddListener (delegate {ChangeParameter ();});
			value3Slider.onValueChanged.AddListener (delegate {ChangeParameter ();});
			value4Slider.onValueChanged.AddListener (delegate {ChangeParameter ();});
			value5Slider.onValueChanged.AddListener (delegate {ChangeParameter ();});
			value6Slider.onValueChanged.AddListener (delegate {ChangeParameter ();});

			colorBottun.onClick.AddListener(delegate {ChangeColor ();});

			audio = GetComponent<AudioSource>();
		}

		// Update is called once per frame
		void Update () {

			AudioListener.GetOutputData(waveData_, 1);
			var volume = waveData_.Select(x => x*x).Sum() / waveData_.Length;
			ChangeParameterWithSound (volume);

		}

		void ChangeParameter(){
			Value1SliderGet = GameObject.Find ("Value 1 Slider");
			value1 = Value1SliderGet.GetComponent<Slider> ().value;

			Value2SliderGet = GameObject.Find ("Value 2 Slider");
			value2 = Value2SliderGet.GetComponent<Slider> ().value;

			Value3SliderGet = GameObject.Find ("Value 3 Slider");
			value3 = Value3SliderGet.GetComponent<Slider> ().value;

			Value4SliderGet = GameObject.Find ("Value 4 Slider");
			value4 = Value4SliderGet.GetComponent<Slider> ().value / 10f;

			Value5SliderGet = GameObject.Find ("Value 5 Slider");
			value5 = Value5SliderGet.GetComponent<Slider> ().value / 10f;

			Value6SliderGet = GameObject.Find ("Value 6 Slider");
			value6 = Value6SliderGet.GetComponent<Slider> ().value / 1f;

			for (int i = 0; i < renderers.Length; i++) {
				renderers [i].material.SetFloat ("_Value1", Random.Range(0,value1));
				renderers [i].material.SetFloat ("_Value2", Random.Range(0,value2));
				renderers [i].material.SetFloat ("_Value3", value3);
				renderers [i].material.SetFloat ("_Value4", value4);
				renderers [i].material.SetFloat ("_Value5", value5);
				renderers[i].transform.eulerAngles = new Vector3(90,180 - value6,0);
			}
		}

		void ChangeColor(){
			randomColorX = new Color(Random.value, Random.value, Random.value, 1.0F);
			randomColorY = new Color(Random.value, Random.value, Random.value, 1.0F);

			for (int i = 0; i < renderers.Length; i++) {
				renderers [i].material.SetColor ("_ColorX", randomColorX);
				renderers [i].material.SetColor ("_ColorY", randomColorY);
			}

			//set color to Pad
			//ColorBlock colors = colorBottun.GetComponent<Button> ().colors;
			var cb = colorBottun.colors;
			var image = colorBottun.GetComponent<Image>();
			cb.normalColor = randomColorY;
			cb.pressedColor = randomColorY;
			image.color = randomColorY;
			colorBottun.colors = cb;

		}

		void ChangeTransform(float vol){
			for (int i = 0; i < renderers.Length; i++) {
				renderers [i].transform.localScale = new Vector3(500,500,500) + Vector3.one * vol * 200;
			}
		}

		void ChangeParameterWithSound(float vol){
			value5 = vol * 0.5F;
			for (int i = 0; i < renderers.Length; i++) {
				renderers [i].material.SetFloat ("_Value5", value5);
			}
		}

			
	}
}
