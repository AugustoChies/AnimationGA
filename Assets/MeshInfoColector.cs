using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshInfoColector : MonoBehaviour {
    public MeshFilter mf;
    public Vector3[] v;

	// Use this for initialization
	void Start () {
        mf = this.gameObject.GetComponent<MeshFilter>();
        v = mf.mesh.vertices;
    }
	
	// Update is called once per frame
	void Update () {
	}
}
