using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    [SerializeField] protected string _name;
    [SerializeField] protected string _description;

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
}
