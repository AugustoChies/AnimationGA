﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDataCollector : MonoBehaviour {
    public static float[] spectrum = new float[512];
    public static float[] bands = new float[8];
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);

        int count = 0;

        for(int i = 0; i< 8;i++)
        {
            float average = 0;
            int samplecount = (int)Mathf.Pow(2, i) * 2;
            if(i ==7)
            {
                samplecount += 2;
            }

            for (int j = 0; j < samplecount; j++)
            {
                average = spectrum[samplecount] * (count + 1);
                count++;                  
            }

            average /= count;

            bands[i] = average * 50;
        }

        
        /*
        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
        */
    }
}