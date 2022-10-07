using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("ITEMS")]
    [SerializeField] private List<ScriptableItem> _scriptableItems = new List<ScriptableItem>();
    [SerializeField] private List<DataItem> _dataItems = new List<DataItem>();

    [Header("CONTENT")]
    [SerializeField] private GameObject _prefabItem;
    [SerializeField] private Transform _content;
    [SerializeField] private List<ContentItem> _itemContainer;

    [Header("DEBUG")]
    [SerializeField] private bool _debugMod = false;
    [SerializeField] private int _debugNbrItems = 5;

    private void Start()
    {
        if (_debugMod)
        {
            _dataItems.Clear();

            GenerateItems();
        }

        InitialiseContent();
    }

    private void GenerateItems()
    {
        if (_scriptableItems.Count > 0)
        {

        }
    }

    private void InitialiseContent()
    {

        if (_content.childCount > 0)
        {
            for (int i = 0; i < _content.childCount; i++)
            {
                Destroy(_content.GetChild(i));
            }
        }

        if (_prefabItem != null)
        {
            for (int i = 0; i < _dataItems.Count; i++)
            {
                ContentItem item = Instantiate(_prefabItem, _content).GetComponent<ContentItem>();
                _itemContainer.Add(item);

                if (_dataItems[i].Stackable)
                {
                    item.NbrItem.enabled = true;
                    item.NbrItem.text = _dataItems[i].NbrItem.ToString();
                }
                else
                {
                    item.NbrItem.enabled = false;
                }

                item.ImageItem.sprite = _dataItems[i].Sprite;
            }
        }
    }
}
