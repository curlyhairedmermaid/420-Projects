using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class BranchSegment : MonoBehaviour {

    public Transform endPoint;
    public BranchSegment prefabeBranch;
	// Use this for initialization
	void Start () {
		
	}
    public void Grow(float scale, Vector3 localEuler)
    {
        if (scale < .3f) return;
        BranchSegment newBranch = Instantiate(prefabeBranch, endPoint.position, Quaternion.identity, transform);
        newBranch.transform.localScale = Vector3.one * scale;
        newBranch.transform.localEulerAngles = localEuler;
        newBranch.Grow(scale * .75f, new Vector3(0,0,-10));
        newBranch.Grow(scale * .75f, new Vector3(0, 0, 10));
    }
	
	// Update is called once per frame
	void Update () {
		
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
            (target as BranchSegment).Grow(1, Vector3.zero);

        }

    }
    


}