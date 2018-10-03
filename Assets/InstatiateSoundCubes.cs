using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateSoundCubes : MonoBehaviour {
    public GameObject cubeprefab;
    GameObject[] soundcubes = new GameObject[8];

	// Use this for initialization
	void Start () {
		for (int i = 0; i<8; i++)
        {
            GameObject inst = Instantiate(cubeprefab,this.transform.position + new Vector3(0.6f * i,0,0),Quaternion.identity,this.transform);
            soundcubes[i] = inst;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 8; i++)
        {
            soundcubes[i].transform.localScale = new Vector3(0.5f, SoundDataCollector.bands[i] + 0.5f, 1);
        }
    }
}
