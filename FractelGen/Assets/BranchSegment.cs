using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class BranchSegment : MonoBehaviour {

    public Transform endPoint;
    public Transform TopPosZ;
    public Transform TopNegZ;
    public Transform TopPosX;
    public Transform TopNegX;
    public Transform Mid1PosZ;
    public Transform Mid1NegZ;
    public Transform Mid1NegX;
    public Transform Mid1PosX;
    public Transform Mid2NegZ;
    public Transform Mid2PosZ;
    public Transform Mid2NegX;
    public Transform Mid2PosX;
    public Transform BotPosZ;
    public Transform BotNegZ;
    public Transform BotPosX;
    public Transform BotNegX;
    public BranchSegment prefabeCoral;
	// Use this for initialization
	void Start () {
		
	}
    public void Grow(float scale, Vector3 localEuler)
    {
        GameObject[] coral = GameObject.FindGameObjectsWithTag("polup");
        Transform[] coralTransforms = new Transform[coral.Length];
        for (int i = 0; i < coral.Length; i++)
        {
            coralTransforms[i] = coral[i].transform;
            if (scale < .3f) return;
            BranchSegment newCoral = Instantiate(prefabeCoral, coral[i].transform, Quaternion.identity, transform);
            newCoral.transform.localScale = Vector3.one * scale;
            newCoral.transform.localEulerAngles = localEuler;
            newCoral.Grow(scale * .75f, new Vector3(0, 0, -10));
        }
       
        
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