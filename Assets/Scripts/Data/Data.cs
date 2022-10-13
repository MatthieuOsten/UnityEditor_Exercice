using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    [SerializeField] protected string _name;
    [SerializeField] protected string _description;

    [SerializeField] private List<Specificity> _specificities = new List<Specificity>();

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }

    public List<Specificity> Specificities { get { return _specificities; } }

    public bool SpecificityIsActive(string name)
    {
        foreach (var item in Specificities)
        {
            if (item.GetType().ToString() == name)
            {
                return true;
            }

        }

        return false;
    }

    public Specificity GetSpecificity(string name)
    {
        foreach (var item in Specificities)
        {
            if (item.GetType().ToString() == name)
            {
                return item;
            }

        }

        return null;
    }

    public bool TryGetSpecificity(string name,out Specificity specificity)
    {
        foreach (var item in Specificities)
        {
            if (item.GetType().ToString() == name)
            {
                specificity = item;
                return true;
            }

        }

        specificity = null;
        return false;
    }

    protected void Initialise(string name, string description) { 
    
        _name = name;
        _description = description;
    
    }
}
