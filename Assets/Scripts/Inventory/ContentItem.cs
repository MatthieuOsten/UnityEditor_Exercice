using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContentItem : MonoBehaviour
{
    [SerializeField] private Image _imageItem;
    [SerializeField] private TextMeshProUGUI _nbrItem;

    public Image ImageItem => _imageItem;
    public TextMeshProUGUI NbrItem => _nbrItem;
}
