using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneVertex : MonoBehaviour {
    public GameObject original;
    public MeshFilter mf;

	// Use this for initialization
	void Start () {
        mf = this.gameObject.GetComponent<MeshFilter>();
    }
	
	// Update is called once per frame
	void Update () {
        mf.mesh.SetVertices(original.GetComponent<MeshInfoColector>().newv);
	}
}
