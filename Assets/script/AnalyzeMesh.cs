using UnityEngine;
using System.Collections;

public class AnalyzeMesh : MonoBehaviour {

	public float randomValue = 2f;
	public Vector3[] baseVerticles;
	public int[] triangles;


	void Start()
	{
		//Understand the values of each verticles, uv, and triangles
		Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
		baseVerticles = new Vector3[mesh.vertices.Length];

		for(int i = 0; i < mesh.vertices.Length; i++)
		{
			
			//Vector3 pos = mesh.vertices;
		}

		for(int i = 0; i < mesh.uv.Length; i++)
		{
			
		}
			
		for(int i = 0; i < mesh.triangles.Length; i++)
		{
			
		}

		baseVerticles = mesh.vertices;
			
	}

	void Update(){
		//test modification
		//Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
		//Vector3[] newVerticles = new Vector3[mesh.vertices.Length];
		//randomValue = Random.Range (0f, 1f);
		/*
		for (int i = 0; i < mesh.vertices.Length; i++) {
			newVerticles [i] = new Vector3 (baseVerticles [i].x * randomValue, baseVerticles [i].y * randomValue, baseVerticles[i].z * randomValue);
		}
		*/


		//mesh.vertices = newVerticles;
	}
}