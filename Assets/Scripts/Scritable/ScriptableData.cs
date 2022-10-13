using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableData : ScriptableObject
{
    [SerializeField] protected string _name;
    [SerializeField] protected string _description;

    [SerializeField] private List<string> _tags = new List<string>();

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }

    public List<string> Tags { get { return _tags; } }

    public bool TagIsHere(string name) { return _tags.Contains(name); }
}
