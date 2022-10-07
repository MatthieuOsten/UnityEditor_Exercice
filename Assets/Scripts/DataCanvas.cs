using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataCanvas : Data
{
    [SerializeField] private Canvas _actualCanvas;

    public Canvas actualCanvas { 
        set {
            value.gameObject.SetActive(false);
            _actualCanvas = value; 
        } 
    }

    public bool IsActived {
        get {
            if (_actualCanvas == null) return false;

            return _actualCanvas.gameObject.activeSelf; 
        } 
    }

    public void SetActive(bool valueBool)
    {
        if (_actualCanvas != null)
        {
            _actualCanvas.gameObject.SetActive(valueBool);
        }

    }
}