using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    public float colorRange = 0.1f;
    public bool _adjustScale = true;
    public bool _adjustColor = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_adjustScale)
        {
            if (_useBuffer)
            {
                transform.localScale = new Vector3((AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale, (AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale, (AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale);
            }
            else
            {
                transform.localScale = new Vector3((AudioPeer._freqBand[_band] * _scaleMultiplier) + _startScale, (AudioPeer._freqBand[_band] * _scaleMultiplier) + _startScale, (AudioPeer._freqBand[_band] * _scaleMultiplier) + _startScale);
            }
        }

        if(GetComponent<Renderer>().material!= null) 
        {
            if (_adjustColor)
            {
                GetComponent<Renderer>().material.color = new Color(AudioPeer._freqBand[_band] + colorRange, 1f - AudioPeer._freqBand[_band] + colorRange, 0.5f, 1f);
            }
        }
    }
}
