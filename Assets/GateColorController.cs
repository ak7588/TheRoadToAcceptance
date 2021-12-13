using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateColorController : MonoBehaviour
{
    public MeshRenderer meshRender;

    public Color first;
    public Color last;
    private Color current;

    //this changes the transition property
    private float _transition = 0;

    public float transition
    {

        get
        {
            return _transition;

        }
        set
        {
            _transition = Mathf.Clamp01(value);

            current = Color.Lerp(first, last, _transition);

            meshRender.material.color = current;

        }

    }

    private void Awake()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        transition = 0;
    }
}
