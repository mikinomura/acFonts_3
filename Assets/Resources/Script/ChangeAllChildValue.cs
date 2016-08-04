using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using MidiJack;


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
		private Slider valueSlider;
		public Button colorButton;
		public Button meshBottun;

		public bool soundEffect;

		public bool colorChange;

		//for sound
		private AudioSource audio_;
		float[] waveData_ = new float[1024];

		//for sound FFT
		public int resolution = 1024;
		public Transform lowMeter, midMeter, highMeter;
		public float lowFreqThreshold = 14700, midFreqThreshold = 29400, highFreqThreshold = 44100;
		public float lowEnhance = 1f, midEnhance = 10f, highEnhance = 100f;

		public enum MODE
		{
			ALL,
			AIRCORD
		}

		public MODE mode;
		// Use this for initialization
		void Start () {

			mode = MODE.AIRCORD;
			renderers = GetComponentsInChildren<Renderer>();

			//set custom shader
			Shader mainShader = Resources.Load ("acFonts/Vertex Animation") as Shader;
			for (int i = 0; i < renderers.Length; i++) {
				//renderers [i].material.shader = mainShader;
			}

			//Adds a listener to the main slider and invokes a method when the value changes.
			ChangeColor();

			value1Slider.onValueChanged.AddListener (delegate {ChangeParameter (1);});
			value2Slider.onValueChanged.AddListener (delegate {ChangeParameter (2);});
			value3Slider.onValueChanged.AddListener (delegate {ChangeParameter (3);});
			value4Slider.onValueChanged.AddListener (delegate {ChangeParameter (4);});
			value5Slider.onValueChanged.AddListener (delegate {ChangeParameter (5);});
			value6Slider.onValueChanged.AddListener (delegate {ChangeParameter (6);});
			value7Slider.onValueChanged.AddListener (delegate {ChangeParameter (7);});


			colorButton.onClick.AddListener(delegate {ChangeColor ();});

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

		public void ChangeParameter(int number){

			var name = "Value " + number + " Slider";
			var propertyName = "_Value" + number;

			Value1SliderGet = GameObject.Find (name);
			value1 = Value1SliderGet.GetComponent<Slider> ().value;

			for (int i = 0; i < renderers.Length; i++) {
				if (number == 6) {
					renderers[i].transform.eulerAngles = new Vector3(90,180 - value1,0);
				} else {
					renderers [i].material.SetFloat (propertyName, Random.Range (0, value1));
				}

			}
			ChooseLetter ();
		}

		public void ChangeColor(){
			randomColorX = new Color(Random.value, Random.value, Random.value, 1.0F);
			randomColorY = new Color(Random.value, Random.value, Random.value, 1.0F);

			for (int i = 0; i < renderers.Length; i++) {
				renderers [i].material.SetColor ("_ColorX", randomColorX);
				renderers [i].material.SetColor ("_ColorY", randomColorY);
			}

			if (colorChange) {
				//set color to button
				var imageMaterial = colorButton.GetComponent<Image> ().material;
				imageMaterial.SetColor ("_Color", randomColorX);
				imageMaterial.SetColor ("_Color2", randomColorY);
			}

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
			value3 = high * 2F;
			for (int i = 0; i < renderers.Length; i++) {
				renderers [i].material.SetFloat ("_Value3", value3);
				renderers [i].material.SetFloat ("_Value4", value4);

			}
		}

		void ChooseLetter(){
			for (int i = 0; i < renderers.Length; i++) {
				var abc = "s";
				if (abc.Contains (renderers [i].name)) {
					print ("contain:" + renderers [i].name);
				}
			}
		}

		public void ShowAircord()
		{
			foreach(Transform tt in gameObject.transform)
			{
				/*
				if (!tt.name.Contains ("b")) {
					if (!tt.name.Contains ("a") && !tt.name.Contains ("i") && !tt.name.Contains ("r") && !tt.name.Contains ("c") && !tt.name.Contains ("d") && !tt.name.Contains ("o")) {
						tt.gameObject.GetComponent<AnalyzeMesh> ().encValue = 5F;
					}
				} else {
					print (tt.name);
				}*/
				tt.gameObject.GetComponent<AnalyzeMesh> ().encValue = 5F;
			}
		}

		public void Bigger(){
			foreach (Transform tt in gameObject.transform) {

				if (mode == MODE.ALL) {
					if (!tt.name.Contains ("a") && !tt.name.Contains ("i") && !tt.name.Contains ("r") && !tt.name.Contains ("c") && !tt.name.Contains ("d") && !tt.name.Contains ("o") && !tt.name.Contains ("l") && !tt.name.Contains ("b")) {
						tt.gameObject.GetComponent<AnalyzeMesh> ().Smaller ();
					} else {
						tt.gameObject.GetComponent<AnalyzeMesh> ().SmallerThenShowUp ();
					}
					//mode = MODE.AIRCORD;
						
				}
					
				if (mode == MODE.AIRCORD) {
					if (!tt.name.Contains ("a") && !tt.name.Contains ("i") && !tt.name.Contains ("r") && !tt.name.Contains ("c") && !tt.name.Contains ("d") && !tt.name.Contains ("o") && !tt.name.Contains ("l") && !tt.name.Contains ("b")) {
						tt.gameObject.GetComponent<AnalyzeMesh> ().Bigger ();
					} else {

						tt.gameObject.GetComponent<AnalyzeMesh> ().BackAndBigger ();
					}
					//mode = MODE.ALL;
				}


			}
			/*
			if (mode == MODE.ALL) {
				mode = MODE.AIRCORD;
			} else {
				mode = MODE.ALL;
			}
			*/
		}
			
	}
}
