using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VoxelTerrainSpawner : MonoBehaviour {
	public GameObject voxelPrefab;
	float zoom = .09f;
	public float threshold = 100f;
	public int resolution = 50;
	public float yBonusScale = 50;
	// Use this for initialization
	void Start () {
		GenerateVoxels ();	
	}
    void Update()
    {
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            zoom += .01f;
        }
        else if (d < 0f)
        {
            zoom -= .01f;
        }
    }
	void onValidate(){
		GenerateVoxels ();
	}
	void GenerateVoxels(){
		//DESTROY ALL CHILDREN
		//while (transform.childCount > 0) {
		//	Destroy (transform.GetChild (0).gameObject);

		//}

		foreach (Transform child in transform) {
			DestroyImmediate(child.gameObject);
		}
		//SPAWN CHILDREN
		for (int x = 0; x < resolution; x++) {
			for (int y = 0; y < resolution; y++) {  //vertical axis
				for (int z = 0; z < resolution; z++) {
					
					float val = fakePerlin3D(x * zoom,y * zoom, z * zoom);

					val += y / yBonusScale;
					// .1 --> 1 voxel
					// .9 --> 9 voxel

					if (val > threshold)
						continue;//threshold

					Vector3 pos = new Vector3 (x, y, z);
					GameObject obj = Instantiate (voxelPrefab, pos, Quaternion.identity, transform);
					//obj.GetComponent<MeshRenderer> ().material.color = Random.ColorHSV (0, 1);



				}
			}
		}
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
