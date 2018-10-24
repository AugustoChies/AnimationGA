using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour {
    public List<float> effectWeights;
    public float pointAutorithy = 1;
    public Vector3 moveDirection;
    public int channel;
    public Vector3 originalpos;
    float bandfreq = 0;

    // Use this for initializatio n
    void Start () {
		if(pointAutorithy < 1)
        {
            pointAutorithy = 1;
        }
        moveDirection.Normalize();

        originalpos = this.transform.position;        
        
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

        this.transform.position = originalpos + (moveDirection * bandfreq);
	}

    public void ApplyWeights(List<Vector3> v, Vector3 meshPosition)
    {
        float distance,weight;
        float lowest = 100;
        float highest = 0;
        for (int i = 0; i < v.Count; i++)
        {
            distance = Vector3.Distance(meshPosition + v[i] ,this.transform.position);
            weight = pointAutorithy / (distance * distance);

            if (weight < lowest) lowest = weight;
            if (weight > highest) highest = weight;

            effectWeights.Add(weight);
        }
    }
}
