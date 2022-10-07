using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] private List<DataCanvas> _listCanvas = new List<DataCanvas>();

    public void DisableAllCanvas()
    {
        foreach (DataCanvas canvas in _listCanvas)
        {
            canvas.SetActive(false);
        }
    }

    public void ActiveCanvas(int index)
    {
        DisableAllCanvas();

        if (index >= 0 && index < _listCanvas.Count)
        {
            _listCanvas[index].SetActive(true);
        }

    }

    public void ActiveCanvas(string name)
    {
        DisableAllCanvas();

        foreach (DataCanvas canvas in _listCanvas)
        {
            if (canvas.Name == name)
            {
                canvas.SetActive(true);
                return;
            }
        }
    }

    public bool TryActiveCanvas(string name)
    {
        DisableAllCanvas();

        foreach (DataCanvas canvas in _listCanvas)
        {
            if (canvas.Name == name)
            {
                canvas.SetActive(true);
                return true;
            }
        }

        return false;
    }
}
