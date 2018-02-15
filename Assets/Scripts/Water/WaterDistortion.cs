using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created using https://www.youtube.com/watch?v=3MoHJtBnn2U
public class WaterDistortion : MonoBehaviour {

	public float power 		= 3;
	public float scale 		= 1;
	public float timeScale 	= 1;

	private float offsetX;
	private float offsetY;
	private MeshFilter meshFilter;

	// Use this for initialization
	void Start () {
		meshFilter = GetComponent<MeshFilter> ();
		Distort ();
	}
	
	// Effect the changing of the mesh
	// Update is called once per frame
	void Update () {
		Distort ();
		offsetX += Time.deltaTime * timeScale;
		offsetY += Time.deltaTime * timeScale;
	}



	void Distort(){
		Vector3[] vertices = meshFilter.mesh.vertices;

		for (int i = 0; i < vertices.Length; i++) {
			vertices [i].y = CalculateHeight (vertices [i].x, vertices [i].z) * power;

		}
		meshFilter.mesh.vertices = vertices;
	}

	float CalculateHeight(float x, float y){
		float coordinateX = x * scale + offsetX;
		float coordinateY = y * scale + offsetY;

		return Mathf.PerlinNoise (coordinateX, coordinateY);

	}
}
