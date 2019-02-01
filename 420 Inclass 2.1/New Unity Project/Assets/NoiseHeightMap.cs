using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseHeightMap : MonoBehaviour {

	Terrain terrain;
	public float zoom = 25;
	public float squash = .05f;

	float offsetX = 0;
	float offsetY = 0;
	float offsetZ = 0;
	float speed = 20;
	// Use this for initialization
	void Start () {
		terrain = GetComponent<Terrain> ();
		GenerateHeightMap ();
	}
	
	// Update is called once per frame
	void Update () {
		offsetZ += Time.deltaTime * speed;
		GenerateHeightMap ();
	}

	void OnValidate(){
		terrain = GetComponent<Terrain> ();
		GenerateHeightMap ();
	}

	void GenerateHeightMap(){
		//Mathf.PerlinNoise ();
		int w = terrain.terrainData.heightmapWidth;
		int h = terrain.terrainData.heightmapHeight;

		float[,] data = new float[w, h];
		for (int x = 0; x < data.GetLength (0); x++) {
			for (int y = 0; y < data.GetLength (1); y++) {

				float coordinateX = (x + offsetX) * zoom;
				float coordinateY = (y + offsetY) * zoom;
				float coordinateZ = (offsetZ) * zoom;
				float val = fakePerlin3D (coordinateX, coordinateY, coordinateZ);//Mathf.PerlinNoise (coordinateX, coordinateY);
				val *= squash;
				data[x, y] = val;
		}
	}
		terrain.terrainData.SetHeights(0,0,data);
}

	float fakePerlin3D(float x, float y, float z){
		float a =Mathf.PerlinNoise (x, y);
		float b =Mathf.PerlinNoise (y, z);
		float c =Mathf.PerlinNoise (x, z);
		float d =Mathf.PerlinNoise (y, x);
		float e =Mathf.PerlinNoise (z, y);
		float f =Mathf.PerlinNoise (z, x);

		return(a + b + c + d + e + f) / 6;
	}
}
