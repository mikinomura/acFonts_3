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
		private float value7;
		public Color color;
		private GameObject Value1SliderGet;
		private GameObject Value2SliderGet;
		private GameObject Value3SliderGet;
		private GameObject Value4SliderGet;
		private GameObject Value5SliderGet;
		private GameObject Value6SliderGet;
		private GameObject Value7SliderGet;
		private Color randomColorX;
		private Color randomColorY;

		public Slider value1Slider;
		public Slider value2Slider;
		public Slider value3Slider;
		public Slider value4Slider;
		public Slider value5Slider;
		public Slider value6Slider;
		public Slider value7Slider;
		public Button colorBottun;
		public Button meshBottun;

		public bool soundEffect;

		//for sound
		private AudioSource audio_;
		float[] waveData_ = new float[1024];

		//for sound FFT
		public int resolution = 1024;
		public Transform lowMeter, midMeter, highMeter;
		public float lowFreqThreshold = 14700, midFreqThreshold = 29400, highFreqThreshold = 44100;
		public float lowEnhance = 1f, midEnhance = 10f, highEnhance = 100f;

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
			value7Slider.onValueChanged.AddListener (delegate {ChangeParameter ();});


			colorBottun.onClick.AddListener(delegate {ChangeColor ();});

			audio_ = GetComponent<AudioSource>();
		}

		// Update is called once per frame
		void Update () {
			switch(soundEffect){
			case true:
				ChangeParameterWithSound ();
				break;
			case false:
				//ChangeParameter ();
				break;
			default:
				return;
 			}

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

			Value7SliderGet = GameObject.Find ("Value 7 Slider");
			value7 = Value7SliderGet.GetComponent<Slider> ().value / 1f;




			for (int i = 0; i < renderers.Length; i++) {
				renderers [i].material.SetFloat ("_Value1", Random.Range(0,value1));
				renderers [i].material.SetFloat ("_Value2", Random.Range(0,value2));
				renderers [i].material.SetFloat ("_Value3", value3);
				renderers [i].material.SetFloat ("_Value4", value4);
				renderers [i].material.SetFloat ("_Value5", value5);
				renderers[i].transform.eulerAngles = new Vector3(90,180 - value6,0);
				renderers [i].material.SetFloat ("_Value7", Random.Range(0,value7));
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

		void ChangeParameterWithSound(){

			AudioListener.GetOutputData(waveData_, 1);
			var volume = waveData_.Select(x => x*x).Sum() / waveData_.Length;
			//ChangeParameterWithSound (volume);

			//for sound FFT
			var spectrum = AudioListener.GetSpectrumData(resolution, 0, FFTWindow.BlackmanHarris);
			var deltaFreq = AudioSettings.outputSampleRate / resolution;
			float low = 0f, mid = 0f, high = 0f;

			for (var i = 0; i < resolution; ++i) {
				var freq = deltaFreq * i;
				if      (freq <= lowFreqThreshold)  low  += spectrum[i];
				else if (freq <= midFreqThreshold)  mid  += spectrum[i];
				else if (freq <= highFreqThreshold) high += spectrum[i];
			}

			low  *= lowEnhance;
			mid  *= midEnhance;
			high *= highEnhance;

			value4 = low * 0.05F;
			for (int i = 0; i < renderers.Length; i++) {
				renderers [i].material.SetFloat ("_Value4", value4);
			}
		}

			
	}
}
