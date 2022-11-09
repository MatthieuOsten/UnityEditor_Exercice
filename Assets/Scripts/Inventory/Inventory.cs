using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    enum InventoryMode
    {
        Number,
        Slots,
        weight
    }

    struct actualItem {

        public string name;
        public int number;
        public bool stackable;
    
    }

    [Header("SETTINGS")]
    [SerializeField] private InventoryMode defaultMode = InventoryMode.Number;

    [SerializeField] private int nbrMaxStackable = 10;

    [SerializeField] private int nbrMaxSlots = 42;
    [SerializeField] private float nbrMaxWeight = 42;
    [SerializeField] private int nbrMaxNumber = 42;

    [SerializeField] private bool extraWeightIsAccepted = true;
    [SerializeField] private float defaultWeight = 0.5f;

    [Header("Inventory")]
    [SerializeField] private float actualNbr = 0;

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
    [SerializeField] private int _debugMaxItemDuplicate = 3;

    private void Start()
    {
        if (_debugMod)
        {
            _dataItems.Clear();

            if (_debugMod)
            {
                GenerateDebugItems();
            }
        }

        InitialiseContent();
    }

    private float ActualContentNbr
    {
        get
        {
            float theValue = 0;

            // Change son comportement par rapport au mode de stockage utiliser
            switch (defaultMode)
            {
                case InventoryMode.Number:
                    foreach (var item in _dataItems)
                    {
                        // Recupere le nombre d'objet actuel
                        theValue += item.NbrItem;
                    }
                    break;
                case InventoryMode.Slots:
                    foreach (var item in _dataItems)
                    {
                        // Recupere le nombre de slot pris par item
                        theValue += item.Stackable ? Mathf.Ceil(item.NbrItem / nbrMaxStackable) : 1; 
                    }
                    break;
                case InventoryMode.weight:

                    if (_dataItems[0].GetType() == typeof(DataItem))

                    foreach (var item in _dataItems)
                    {
                        theValue += GetWeightItem(item);
                    }
                    break;
                default:
                    break;
            }

            return theValue;
        }
    }

    private float GetWeightItem(DataItem item)
    {
        Specificity spec = null;
        if (item.TryGetSpecificity(typeof(SpecificityWeight).ToString(), out spec))
        {
            // Oblige "spec" a se convertir en "SpecificityWeight" car on est sur qu'il soit de ce type
            SpecificityWeight specificityWeight = spec as SpecificityWeight;
            return specificityWeight.Weight;
        }
        else
        {
            return defaultWeight;
        }
    }

    private void GenerateDebugItems()
    {
        Debug.Log("Debug : Generate Items");

        if (_scriptableItems.Count > 0 && _dataItems.Count == 0)
        {
            int nbrMax;

            foreach (var item in _scriptableItems)
            {
                DataItem newItem;

                if (item.Stackable)
                {

                    nbrMax = Random.Range(1, _debugMaxItemDuplicate * nbrMaxStackable);

                    do
                    {
                        if (nbrMax >= nbrMaxStackable)
                        {
                            newItem = new DataItem(item.Name, item.Description, item.Name, item.Sprite, nbrMaxStackable, item.Stackable);
                            Debug.Log("Debug : Generate one slot of " + item.Name + " x " + nbrMaxStackable);
                            nbrMax -= nbrMaxStackable;
                        }
                        else
                        {
                            newItem = new DataItem(item.Name, item.Description, item.Name, item.Sprite, nbrMax, item.Stackable);
                            Debug.Log("Debug : Generate one slot of " + item.Name + " x " + nbrMax);
                            nbrMax = 0;
                        }

                        _dataItems.Add(newItem);

                    } while (nbrMax > 0);
                    
                }
                else
                {
                    nbrMax = Random.Range(1, _debugMaxItemDuplicate);

                    for (int i = 0; i < nbrMax; i++)
                    {
                        _dataItems.Add(new DataItem(item.Name, item.Description, item.Name, item.Sprite, 1, item.Stackable));
                        Debug.Log("Debug : Generate one slot of " + item.Name + " x " + 1);
                    }
                }
                
            }
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

                if (_dataItems[i].NbrItem > 1)
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
