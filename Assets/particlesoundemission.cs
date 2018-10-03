using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesoundemission : MonoBehaviour {
    public GeneratorScript ps;
    float original_radius;
	// Use this for initialization
	void Start () {
        ps = GetComponent<GeneratorScript>();
        original_radius = ps.radius;
	}
	
	// Update is called once per frame
	void Update () {
		if(SoundDataCollector.bands[0] > 5 || SoundDataCollector.bands[01] > 5)
        {
            ps.radius *= 5;
            ps.Burst(20);
        }
        ps.radius = original_radius;
	}
}
