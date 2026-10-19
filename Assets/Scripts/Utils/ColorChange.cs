using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public float duration = .2f;
    public Color startColor = Color.white;
    private Color _correctColor;

    private void OnValidate()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _correctColor = meshRenderer.materials[0].GetColor("_BaseColor");
        LerpColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            LerpColor();
        }
    }

    private void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_BaseColor", startColor);
        meshRenderer.materials[0].DOColor(_correctColor, duration).SetDelay(.5f);
    }
}
