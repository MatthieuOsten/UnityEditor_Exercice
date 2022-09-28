using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentString : MonoBehaviour
{
    [Tooltip("Une variable string")]
    [SerializeField] private string valueString = "Hello world";
}