using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CowAudio : MonoBehaviour
{
    public AudioSource watching;
    public AudioSource notwatching;
    public float timer = 0f;
    public bool var = false;
    public bool var1 = false;

        // Use this for initialization
    void Start()
    {

    }
    public void Update()
    {
        if (var)
            timer = timer + Time.deltaTime;
    }
    public void reseter()
    {
        timer = 0f;

    }
    public void looking()
    {
        StartCoroutine(lookStart());
        StartCoroutine(playAudio());
        timer = 0f;
        timer = timer + Time.deltaTime;
        //watching.Play();

    }
    public void notlooking()
    {
        reseter();
        var = false;
        //notwatching.Play();
        StopAllCoroutines();

    }
    IEnumerator lookStart()
    {
        var = true;
        yield return new WaitForSeconds(2f);
        if (var)
            StartCoroutine(playAudio());
        var = false;
    }
    IEnumerator playAudio()
    {

        yield return new WaitForSeconds(2f);
        //word = "yay";
        watching.Play();
    }
}
