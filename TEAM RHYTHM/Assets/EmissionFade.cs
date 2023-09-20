using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EmissionFade : MonoBehaviour
{
    public float duration = 2f;
    public AnimationCurve curve;
    private Color StartColor;
    private Color EndColor;
    public float shiftDebug;
    public float fadeDebug;
    public Color currentColor;
    IEnumerator currentCoroutine;
    bool Collided;
    public float colorCurve;

    void Start()
    {
        currentCoroutine = Shifting();
        StartCoroutine(currentCoroutine);
    }

    private void Update()
    {
        currentColor= GetComponent<Renderer>().material.color;
        if (shiftDebug >= 1)
        {
            /*StopCoroutine(currentCoroutine);
            currentCoroutine = Fading();
            StartCoroutine(currentCoroutine); */
        }
    }
    public void StartShfting()
    {
        StartCoroutine(Shifting());
    }

    IEnumerator Shifting()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            colorCurve = curve.Evaluate(elapsedTime / duration);
            shiftDebug = colorCurve;
            //GetComponent<Renderer>().material.SetColor("_EmissionColor", colorCurve * Mathf.LinearToGammaSpace(2f));
            yield return null;
        }
        //yield return StartCoroutine(Fading());
    }

    /*IEnumerator Fading()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float ColorCurve = curve.Evaluate(elapsedTime / duration);
            fadeDebug = ColorCurve;
            GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f-ColorCurve);
            yield return null;
        }
    }*/

    public void StopCurrentCoroutines()
    {
        StopAllCoroutines();
    }



}
