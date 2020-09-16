using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : MonoBehaviour{

    private float testSound1, testSound2;
    private static float MicLoudness1, MicLoudness2;
    public float sensitivity1 = 0.5f;
    public float sensitivity2 = 0.5f;
    private string[] _devices;
    AudioClip[] _clipRecords;
    private int _sampleWindow = 128;
    private bool _isInitialized;
    public float scaledPos1, scaledPos2;

    void InitMic()
    {
        for(int i = 0; i < _devices.Length; i++)
        {
            if (_devices[i] == null) {
                _devices[i] = Microphone.devices [i];
                _clipRecords[i] = Microphone.Start (_devices[i], true, 999, 44100);
                Debug.Log (_clipRecords[i]);
            }
            Debug.Log("Mic devices: " + Microphone.devices[i] );
        }
    }

    void StopMicrophone()
    {
        for(int i = 0; i < _devices.Length; i++){
            Microphone.End (_devices[i]);
        }
    }

    float LevelMax(string device)
    {
        if(device == _devices[0])
        {
            float levelMax = 0;
            float[] waveData = new float[_sampleWindow];
            int micPosition = Microphone.GetPosition (device) - (_sampleWindow + 1);
            if (micPosition < 0) {
                return 0;
            }
            _clipRecords[0].GetData (waveData, micPosition);
            for (int i = 0; i < _sampleWindow; ++i) {
                float wavePeak = waveData [i] * waveData [i];
                if (levelMax < wavePeak) {
                    levelMax = wavePeak;
                }
            }
            return levelMax;
        }
        else
        {
            float levelMax = 0;
            float[] waveData = new float[_sampleWindow];
            int micPosition = Microphone.GetPosition (device) - (_sampleWindow + 1);
            if (micPosition < 0) {
                return 0;
            }
            _clipRecords[1].GetData (waveData, micPosition);
            for (int i = 0; i < _sampleWindow; ++i) {
                float wavePeak = waveData [i] * waveData [i];
                if (levelMax < wavePeak) {
                    levelMax = wavePeak;
                }
            }
            return levelMax;
        }

    }

    public float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
    
        return(NewValue);
    } 

    void Update()
    {
        MicLoudness1 = LevelMax (_devices[0]);
        MicLoudness2 = LevelMax (_devices[1]);
        testSound1 = MicLoudness1;
        testSound2 = MicLoudness2;
        scaledPos1 = scale(0f, sensitivity1, -14.25f, 4.25f, testSound1);
        scaledPos2 = scale(0f, sensitivity2, -14.25f, 4.25f, testSound2);
        //Debug.Log(_devices[0] + ": " + scaledPos2);
        //Debug.Log("Mic 2: " + scaledPos1);
    }

    void OnEnable()
    {
        _devices = new string[2];
        _clipRecords = new AudioClip[2];
        //_devices[0] = "d1";
        //_devices[1] = "d2";
        InitMic ();
        _isInitialized = true;
    }

    void OnDisable()
    {
        StopMicrophone ();
    }

    void OnDestory()
    {
        StopMicrophone ();
    }

    void OnApplicationFocus(bool focus)
    {
        if (focus) {
            if (!_isInitialized) {
                InitMic ();
                _isInitialized = true;
            }
        }

        if (!focus) {
            StopMicrophone ();
            _isInitialized = false;
        }
    }

}
