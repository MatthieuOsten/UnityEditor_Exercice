using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DATA_", menuName = "Data/Data", order = 1)]
public class ScriptableItem : ScriptableData
{
    [SerializeField] private Sprite _spriteItem;

    /// <summary>
    /// Si l'objet est empilable ou non
    /// </summary>
    [SerializeField] private bool _stackable = false;


    /// <summary>
    /// Retourne si l'objet peux etre empilable
    /// </summary>
    public bool Stackable => _stackable;

    public Sprite Sprite => _spriteItem;
}