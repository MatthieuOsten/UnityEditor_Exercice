using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpecificityWeight : Specificity
{
    [SerializeField] private float _weight = 0;

    public float Weight { get { return _weight; } }

    public void SetWeight(float valueWeight) { _weight = valueWeight; }
}
