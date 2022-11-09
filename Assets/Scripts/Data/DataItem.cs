using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataItem : Data
{
    [SerializeField] private string _nameItem;
    [SerializeField] private Sprite _spriteItem;
    [SerializeField] private int _nbrItem;
    /// <summary>
    /// Si l'objet est empilable ou non
    /// </summary>
    [SerializeField] private bool _stackable = false;

    /// <summary>
    /// Retourne si l'objet peux etre empilable
    /// </summary>
    public bool Stackable => _stackable;

    public Sprite Sprite => _spriteItem;

    public string NameItem { get { return _nameItem; } set { _nameItem = value; } }

    public int NbrItem { 
        get { return _nbrItem; } 
        set {
            if (value > 0)
            {
                _nbrItem = value;
            }
        } 
    }

    public DataItem(string name, string description,string nameItem, Sprite spriteItem, int nbrItem, bool stackable)
    {
        Initialise(name, description);
        NameItem = nameItem;
        _spriteItem = spriteItem;
        NbrItem = nbrItem;
        _stackable = stackable;
    }
}