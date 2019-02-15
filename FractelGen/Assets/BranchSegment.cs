using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class BranchSegment : MonoBehaviour {

    public BranchSegment prefabeCoral;
	// Use this for initialization
    public void Grow(float scale)
    {
        GrowPosZ(scale, new Vector3(0, 0, Random.Range(0, 45)));
        GrowNegz(scale, new Vector3(0, 0, Random.Range(-45, 0)));
        GrowPosX(scale, new Vector3(Random.Range(0, 45), 0, 0));
        GrowNegX(scale, new Vector3(Random.Range(-45, 0), 0, 0));
    }

    public void GrowPosZ(float scale, Vector3 localEuler) {
        GameObject[] coral = GameObject.FindGameObjectsWithTag("PosZPol");
        float localScale = scale;
        for (int i = 0; i < coral.Length; i++)
        {
            if (localScale < .3f) return;
            BranchSegment newCoral = Instantiate(prefabeCoral, coral[i].transform.position, Quaternion.identity, transform);
            localScale *= .3f;
            newCoral.transform.localScale = Vector3.one * scale;
            newCoral.transform.localEulerAngles = localEuler;
            newCoral.GrowPosZ(localScale, new Vector3(0, 0, -10));
        }
    }
    public void GrowNegz(float scale, Vector3 localEuler) {
        GameObject[] coral = GameObject.FindGameObjectsWithTag("NegZPol");
        float localScale = scale;
        for (int i = 0; i < coral.Length; i++)
        {
            if (localScale < .3f) return;
            localScale *= .3f;
            BranchSegment newCoral = Instantiate(prefabeCoral, coral[i].transform.position, Quaternion.identity, transform);
            newCoral.transform.localScale = Vector3.one * scale;
            newCoral.transform.localEulerAngles = localEuler;
            newCoral.GrowNegz(localScale, new Vector3(0, 0, -10));
        }
    }
    public void GrowPosX(float scale, Vector3 localEuler) {
        GameObject[] coral = GameObject.FindGameObjectsWithTag("PosXPol");
        float localScale = scale;
        for (int i = 0; i < coral.Length; i++)
        {
            if (localScale < .3f) return;
            localScale *= .3f;
            BranchSegment newCoral = Instantiate(prefabeCoral, coral[i].transform.position, Quaternion.identity, transform);
            newCoral.transform.localScale = Vector3.one * scale;
            newCoral.transform.localEulerAngles = localEuler;
            newCoral.GrowPosX(localScale, new Vector3(0, 0, -10));
        }
    }
    public void GrowNegX(float scale, Vector3 localEuler) {
        GameObject[] coral = GameObject.FindGameObjectsWithTag("NegXPol");
        float localScale = scale;
        for (int i = 0; i < coral.Length; i++)
        {
            if (localScale < .3f) return;
            localScale *= .3f;
            BranchSegment newCoral = Instantiate(prefabeCoral, coral[i].transform.position, Quaternion.identity, transform);
            newCoral.transform.localScale = Vector3.one * scale;
            newCoral.transform.localEulerAngles = localEuler;
            newCoral.GrowNegX(localScale, new Vector3(0, 0, -10));
        }
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
            (target as BranchSegment).Grow(1);

        }

    }
    


}