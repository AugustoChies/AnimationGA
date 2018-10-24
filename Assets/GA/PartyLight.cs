using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyLight : MonoBehaviour {

    public float fixedpanMultiplier,fixedpanSum; 
    float bandfreq;
    public int channel;
	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
        switch (channel)
        {
            case 1:
                bandfreq = SoundDataCollector.bands[0];
                break;
            case 2:
                bandfreq = SoundDataCollector.bands[1];
                break;
            case 3:
                bandfreq = SoundDataCollector.bands[2] + SoundDataCollector.bands[3];
                break;
            case 4:
                bandfreq = SoundDataCollector.bands[4] + SoundDataCollector.bands[5] + SoundDataCollector.bands[6] + SoundDataCollector.bands[7];
                break;
            default:
                break;
        }

        this.transform.Rotate(this.transform.up, (fixedpanSum + (fixedpanMultiplier * bandfreq)) * Time.deltaTime);
        
	}

}
