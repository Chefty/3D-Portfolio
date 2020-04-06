﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[ExecuteInEditMode]
public class HologramMaterialPropertyBlocks : MonoBehaviour
{
    [Header("General")]
    public float brightness;
    public float alpha;
    public Vector3 direction;

    public Texture2D mainTexture;
    public Color mainColor;

    public Color rimColor;
    public float rimPower;

    public bool enableScanlines;
    public float scanSpeed;
    public float scanTiling;

    public bool enableGlow;
    public float glowSpeed;
    public float glowTiling;

    public bool enableGlitch;
    public float glitchSpeed;
    public float glitchIntensity;

    public float flickerSpeed;

    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    
    void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
        //Shader feature setup
        if (enableScanlines)
            _renderer.sharedMaterial.EnableKeyword("_SCAN_ON");
        else
            _renderer.sharedMaterial.DisableKeyword("_SCAN_ON");
        if (enableGlow)
            _renderer.sharedMaterial.EnableKeyword("_GLOW_ON");
        else
            _renderer.sharedMaterial.DisableKeyword("_GLOW_ON");
        if (enableGlitch)
            _renderer.sharedMaterial.EnableKeyword("_GLITCH_ON");
        else
            _renderer.sharedMaterial.DisableKeyword("_GLITCH_ON");
    }

    void Update()
    {
        if (!_renderer)
            return;

        // Get the current value of the material properties in the renderer.
        _renderer.GetPropertyBlock(_propBlock);

        // Assign our new value.
        _propBlock.SetFloat("_Brightness", brightness);
        _propBlock.SetFloat("_Alpha", alpha);
        _propBlock.SetVector("_Direction", direction);

        if (mainTexture != null)
            _propBlock.SetTexture("_MainTex", mainTexture);
        _propBlock.SetColor("_MainColor", mainColor);

        _propBlock.SetColor("_RimColor", rimColor);
        _propBlock.SetFloat("_RimPower", rimPower);

        _propBlock.SetFloat("_ScanTiling", scanTiling);
        _propBlock.SetFloat("_ScanSpeed", scanSpeed);

        _propBlock.SetFloat("_GlowTiling", glowTiling);
        _propBlock.SetFloat("_GlowSpeed", glowSpeed);

        _propBlock.SetFloat("_GlitchSpeed", glitchSpeed);
        _propBlock.SetFloat("_GlitchIntensity", glitchIntensity);

        _propBlock.SetFloat("_FlickerSpeed", flickerSpeed);

        // Apply the edited values to the renderer.
        _renderer.SetPropertyBlock(_propBlock);
    }
}
