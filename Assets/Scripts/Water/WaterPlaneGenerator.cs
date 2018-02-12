using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneGenerator : MonoBehaviour {

	public float size 			= 1;
	public int gridSize 		= 16;
	public float vertexModifier = 0.5f;

	private MeshFilter filter;


	// Use this for initialization
	private void Start () {
		filter 		= GetComponent<MeshFilter> ();
		filter.mesh = GenerateMesh ();
	}

	private Mesh GenerateMesh(){
		Mesh mesh = new Mesh ();

		var vertices 	= new List<Vector3> ();
		var normals 	= new List<Vector3> ();
		var uvs 		= new List<Vector2> ();

		var triangles   = new List<int>();
		var vertCount 	= gridSize + 1;

		for (int x = 0; x < gridSize + 1; x++) {
			for (int y = 0; y < gridSize + 1; y++) {
				vertices.Add(new Vector3(axisModifier(x, size, gridSize), 0, axisModifier(y, size, gridSize)));
				normals.Add (Vector3.up);
				uvs.Add(new Vector2(axisDividedByGridSize(x, gridSize), axisDividedByGridSize(y, gridSize)));
			}
		}

		triangles = generateTriangles (gridSize);

		mesh.SetVertices (vertices);
		mesh.SetNormals (normals);
		mesh.SetUVs (0, uvs);
		mesh.SetTriangles (triangles, 0);

		return mesh;

	}

	private float axisModifier(int axis, float aSize, int aGridSize){
		return -aSize * vertexModifier + aSize * axisDividedByGridSize(axis, aGridSize);
	}
	
	private float axisDividedByGridSize(int axis, int gridSize){
		return axis / (float)gridSize;
	}


	private List<int> generateTriangles(int size){
		var vertCount = size + 1;
		var triangles 	= new List<int> ();
		for (int i = 0; i < vertCount * vertCount - vertCount; i++) {
			if ((i + 1) % vertCount != 0) {
				triangles.AddRange (new List<int> () {
					i + 1 + vertCount, i + vertCount, i, i, i + 1, i + vertCount + 1
				});
			}
		}
		return triangles;
	}

}
