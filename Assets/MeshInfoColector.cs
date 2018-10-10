using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshInfoColector : MonoBehaviour {
    public MeshFilter mf;
    public List<Vector3> v;
    public List<Vector3> newv;
    public Transform finalpos;
    public GameObject[] cps;


    Vector3 startingpos;
	// Use this for initialization
	void Awake () {
        mf = this.gameObject.GetComponent<MeshFilter>();
        mf.mesh.GetVertices(v);

        foreach (Vector3 item in v)
        {
            newv.Add(item);            
        }

        startingpos = this.transform.position;
    }

    void Start()
    {
        for (int i = 0; i < cps.Length; i++)
        {
            cps[i].GetComponent<ControlPoint>().ApplyWeights(v, this.transform.position);            
        }
    }

    // Update is called once per frame
    void Update () {
        this.transform.position = startingpos;
        this.transform.localScale = new Vector3(1, 1, 1);

        Vector3[] extramove = new Vector3[newv.Count];
        for (int i = 0; i < cps.Length; i++)
        {
            Vector3 movement = cps[i].transform.position - cps[i].GetComponent<ControlPoint>().originalpos;
            
            for (int j = 0; j < newv.Count; j++)
            {
                extramove[j] += movement * cps[i].GetComponent<ControlPoint>().effectWeights[j];
            }
        }

        for (int j = 0; j < newv.Count; j++)
        {
            newv[j] = v[j] + extramove[j];
        }

        mf.mesh.SetVertices(newv);

        this.transform.position = finalpos.position;
        this.transform.localScale = finalpos.localScale;
	}
}
