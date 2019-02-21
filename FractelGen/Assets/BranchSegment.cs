using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class BranchSegment : MonoBehaviour {

    public BranchSegment prefabeCoral;
    public Transform[] spawnPoints;
    // Use this for initialization
	[Range(2, 8)] public int iterations = 3;
    public void Build(float scale)
    {
		List<CombineInstance> meshes = new List<CombineInstance> ();

		Grow (iterations, meshes, Vector3.zero, Quaternion.identity, 1);

		Mesh mesh = new Mesh ();
		mesh.CombineMeshes (meshes.ToArray());
		MeshFilter meshFilter = GetComponent<MeshFilter> ();
		meshFilter.mesh = mesh;
    }

	public void Grow(int num, List<CombineInstance> meshes, Vector3 pos, Quaternion rot, float scale) {
		if (num <= 0)
			return; 
		CombineInstance inst = new CombineInstance ();
		inst.transform = Matrix4x4.TRS (pos, rot, Vector3.one * scale);
		meshes.Add (inst);
		num--;

		pos = inst.transform.MultiplyPoint (new Vector3 (0, 1, 0));
		Quaternion rot1 =  rot * Quaternion.Euler (0, 0, 45);
		Quaternion rot2 =  rot * Quaternion.Euler (0, 0, 45);
		scale *= .75f;

		Grow (num, meshes, pos, rot, scale);
    }
   public void combineMeshes()
    {

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

		int i = 0;
		while (i < meshFilters.Length)
		{
			combine[i].mesh = meshFilters[i].sharedMesh;
			combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
			meshFilters[i].gameObject.SetActive(false);

			i++;
		}
        transform.GetComponent<MeshFilter>().sharedMesh = new Mesh();
        transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);
    }
}

   
[CustomEditor(typeof(BranchSegment))]
public class BranchSegmentEditor : Editor
{
    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        if (GUILayout.Button("GROW"))
        {
            (target as BranchSegment).Build(1);

        }

    }
    


}