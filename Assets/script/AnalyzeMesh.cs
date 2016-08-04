using UnityEngine;
using System.Collections;

public class AnalyzeMesh : MonoBehaviour {

	public float randomValue = 2f;
	public Vector3[] baseVerticles;
	public int[] triangles;
	Mesh mesh;
	Vector3[] baseVertices;
	Vector3[] newVerticles;
	public float encValue;
	public Vector3 labPos;
	Vector3 pos;

	float time;

	void Start()
	{
		//Understand the values of each verticles, uv, and triangles
		mesh = gameObject.GetComponent<MeshFilter>().mesh;
		baseVertices = new Vector3[mesh.vertices.Length];
		time = 0F;
		encValue = 0F;
		pos = gameObject.transform.position;

		for(int i = 0; i < mesh.vertices.Length; i++)
		{
			print (mesh.vertices[i]);
			//Vector3 pos = mesh.vertices;
		}

		for(int i = 0; i < mesh.uv.Length; i++)
		{
			
		}
			
		for(int i = 0; i < mesh.triangles.Length; i++)
		{
			
		}

		newVerticles = new Vector3[mesh.vertices.Length];
		for (int i = 1; i < mesh.vertices.Length; i++){
				var x = mesh.vertices [i - 1].x;
				var y = mesh.vertices [i - 1].y;
				var z = mesh.vertices [i - 1].z;
				newVerticles [i] = new Vector3(x,y,z);
		}
			
		baseVertices = mesh.vertices;
			
	}

	void Update(){
		//test modification
		//Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
		//Vector3[] newVerticles = new Vector3[mesh.vertices.Length];
		//randomValue = Random.Range (0f, 1f);
		Vector3[] newNew = new Vector3[mesh.vertices.Length];
		time += Time.deltaTime * encValue;

		if (time < 5F) {
			for (int i = 0; i < mesh.vertices.Length; i++) {
				newNew [i] = Vector3.Lerp (mesh.vertices [i], newVerticles [i], Time.deltaTime * encValue);
			}

		} else {
			for (int i = 0; i < mesh.vertices.Length; i++) {
				newNew [i] = Vector3.Lerp (mesh.vertices [i], baseVertices [i], Time.deltaTime * encValue);
			}

			if(time > 10F)
			{
				time = 0f;
				encValue = 0F;
			}
		}

		mesh.vertices = newNew;

	}

	public void Bigger()
	{
		
		iTween.ScaleTo (gameObject, iTween.Hash(
			"x", 500F,
			"y", 500F,
			"z", 500F,
			"time", 0.1F,
			"delay",0.6F
		));


	}

	public void Smaller(){
		iTween.ScaleTo (gameObject, iTween.Hash(
			"x", 1F,
			"y", 1F,
			"z", 1F,
			"time", 0.5F,
			"easeType","easeInBounce"
		));
	}

	public void SmallerThenShowUp()
	{
		iTween.ScaleTo (gameObject, iTween.Hash(
			"x", 1F,
			"y", 1F,
			"z", 1F,
			"time", 0.5F,
			"easeType", "easeInBounce"
		));

		iTween.MoveTo (gameObject, iTween.Hash(
			"x",labPos.x * 2F,
			"y",labPos.y * 2F,
			"time",0.1F,
			"delay",0.5F
		));

		iTween.ScaleTo (gameObject, iTween.Hash(
			"x", 500F,
			"y", 500F,
			"z", 500F,
			"time", 0.5F,
			"delay", 0.6F,
			"easeType", "easeInBounce"
		));

		//183,554
		//240
		//263
		//309
		//360
		//407
		//454
		//529
		//552
		//607

	}

	public void BackAndBigger()
	{
		
		iTween.ScaleTo (gameObject, iTween.Hash(
			"x", 1F,
			"y", 1F,
			"z", 1F,
			"time", 0.5F,
			"easeType", "easeInBounce"
		));

		iTween.ScaleTo (gameObject, iTween.Hash(
			"x", 500F,
			"y", 500F,
			"z", 500F,
			"time", 0.5F,
			"delay", 0.6F,
			"easeType", "easeInBounce"
		));

		iTween.MoveTo (gameObject, iTween.Hash(
			"x",pos.x,
			"y",pos.y,
			"time",0.1F,
			"delay",0.5F
		));


	}
}
