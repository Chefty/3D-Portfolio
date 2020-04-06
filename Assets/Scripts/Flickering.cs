using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flickering : MonoBehaviour
{
    public Image image;
    public Light spotLight;
    [Tooltip("Lower is the level higher will be the flickering.")]
    [Range(0.0f, 1.0f)]
    public float flickeringLevel;

    private float defaultLightIntensity;

    private 
    // Start is called before the first frame update
    void Start()
    {
        if (spotLight != null)
            defaultLightIntensity = spotLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        var flicker = Random.Range(flickeringLevel, 1f);
        if (image != null)
            image.color = new Color(image.color.r, image.color.g, image.color.b, flicker);
        if (spotLight != null)
            spotLight.intensity = defaultLightIntensity * flicker;
    }
}
