using UnityEngine;
using System.Collections;
using System.Linq;

public class Sound : MonoBehaviour
{
	public AudioClip clip;
	public int lengthYouWant;

	void Start()
	{
		var data = new float[lengthYouWant];
		clip.GetData(data, 0);
	}

	private float[] waveData_ = new float[1024];

	void Update()
	{
		AudioListener.GetOutputData(waveData_, 1);
		var volume = waveData_.Select(x => x*x).Sum() / waveData_.Length;
		//transform.localScale = Vector3.one * 0.5F;
	}
}