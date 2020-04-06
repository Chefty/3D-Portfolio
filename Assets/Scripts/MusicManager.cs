using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Toggle toggleMusic;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        toggleMusic = GetComponentInChildren<Toggle>();
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            toggleMusic.isOn = !toggleMusic.isOn;
            if (toggleMusic.isOn)
                music.Stop();
            else
                music.Play();
        }
    }
}
