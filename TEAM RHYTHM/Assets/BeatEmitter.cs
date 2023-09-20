using UnityEngine;
using UnityEngine.Events;

public class BeatEmitter : MonoBehaviour
{

    public float BPM = 100f;
    public Color StartColor;
    public Color EndColor;
    private Material mat;
    public UnityEvent BeatPulse;
    public float baseValueChecker;
    bool beatPulsed;
    

    // Use this for initialization
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        //
    }

    // Update is called once per frame
    void Update()
    {
        var baseValue = Mathf.Cos(((Time.time * Mathf.PI) * (BPM / 60f)) % Mathf.PI);
        baseValueChecker = baseValue;
        var target = Color.Lerp(EndColor, StartColor, baseValue);
        if(GetComponent<Renderer>() != null)
        {
            mat.SetColor("_EmissionColor", target);
        }
        if(baseValue >= 0.99f) 
        {
            beatPulsed = false;
            BeatPulse.Invoke();
        }
        else
        {
            beatPulsed = false;
        }

    }
}
