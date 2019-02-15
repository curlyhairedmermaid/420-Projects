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

    public void Build(float scale)
    {
        Grow("PosZPol", scale, new Vector3(0, 0, Random.Range(0, 45)));
        Grow("NegZPol", scale, new Vector3(0, 0, Random.Range(-45, 0)));
        Grow("PosXPol", scale, new Vector3(Random.Range(0, 45), 0, 0));
        Grow("NegXPol", scale, new Vector3(Random.Range(-45, 0), 0, 0));
       combineMeshes();
    }

    public void Grow(string tag, float scale, Vector3 localEuler) {
        GameObject[] coral = GameObject.FindGameObjectsWithTag(tag);
        float localScale2 = scale;
        for (int i = 0; i < coral.Length; i++)
        {
            if (localScale2 < .3f) return;
            BranchSegment newCoral = Instantiate(prefabeCoral, coral[i].transform.position, Quaternion.identity, transform);
            localScale2 *= .3f;
            newCoral.transform.localScale = Vector3.one * localScale2;
            newCoral.transform.localEulerAngles = localEuler;
            newCoral.Grow(tag, localScale2, localEuler);
        }
    }
   public void combineMeshes()
    {

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

       for (int i = 0; i < meshFilters.Length; i++)
            {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

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