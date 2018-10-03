using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshInfoColector : MonoBehaviour {
    public MeshFilter mf;
    public List<Vector3> v;
    public List<Vector3> newv;

	// Use this for initialization
	void Start () {
        mf = this.gameObject.GetComponent<MeshFilter>();
        mf.mesh.GetVertices(v);

        foreach (Vector3 item in v)
        {
            newv.Add(item);            
        }

    }
	
	// Update is called once per frame
	void Update () {
        for(int i=0; i < newv.Count/2; i++)
        {
            newv[i] = v[i] + new Vector3(SoundDataCollector.bands[0], 0, 0);
        }
        mf.mesh.SetVertices(newv);
	}
}
