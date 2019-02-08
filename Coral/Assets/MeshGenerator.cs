using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {
    MeshFilter meshFilter;
	// Use this for initialization
	void Start ()
    {
        meshFilter = GetComponent<MeshFilter>();

        GenerateAMesh();
    }

    private void GenerateAMesh()
    {
        //Generate a mesh!
       
        //mesh.vertices
        // mesh.normals
        //mesh.colors
        //mesh.uv
        //mesh.triangles

        List<Vector3> verticies = new List<Vector3>();

        verticies.Add(new Vector3(0, 0, 0));
        verticies.Add(new Vector3(0, 1, 0));
        verticies.Add(new Vector3(1, 0, 0));
        verticies.Add(new Vector3(1, 1, 0));

        List<Vector2> uvs = new List<Vector2>();
        uvs.Add(new Vector2(0, 0));
        uvs.Add(new Vector2(0, 1));
        uvs.Add(new Vector2(1, 0));
        uvs.Add(new Vector2(1, 1));

        List<Vector3> normals = new List<Vector3>();
        normals.Add(new Vector3(0, 0, 1));
        normals.Add(new Vector3(0, 0, 1));
        normals.Add(new Vector3(0, 0, 1));
        normals.Add(new Vector3(0, 0, 1));

        List<int> tris = new List<int>();
        tris.Add(0);
        tris.Add(1);
        tris.Add(2);

        tris.Add(1);
        tris.Add(3);
        tris.Add(2);
        print(verticies);
        Mesh mesh = new Mesh();

        mesh.SetVertices(verticies);
        mesh.SetUVs(0, uvs);
        mesh.SetNormals(normals);
        mesh.SetTriangles(tris, 0);

        meshFilter.mesh = mesh;
    }

    // Update is called once per frame
    void Update () {
		
	}

}
