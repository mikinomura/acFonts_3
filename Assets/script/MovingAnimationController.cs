using UnityEngine;
using System.Collections;

namespace acFonts
{

public class MovingAnimationController : MonoBehaviour {

		float zPos;
	// Use this for initialization
	void Start () {
	
			zPos = gameObject.transform.position.z;
			FloatAnimation ();

	}
	
	// Update is called once per frame
	void Update () {
	

	}
		void FloatAnimation()
		{
			iTween.MoveTo (this.gameObject, iTween.Hash(
				"z", zPos * (1 + Random.Range(-0.1F,0.1F)),
				"time", 2F,
				"loopType", "pingPong",
				"easeType", "easeInOutCubic"
			));

		}
}


}
