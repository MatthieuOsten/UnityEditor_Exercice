using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableData : ScriptableObject
{
    [SerializeField] protected string _name;
    [SerializeField] protected string _description;

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
}
