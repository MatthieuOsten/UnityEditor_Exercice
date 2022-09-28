
using UnityEngine;
using UnityEditor;
using System.Reflection;

public class Tools : MonoBehaviour
{
    [MenuItem("Tools/Log Console")]
    static void LogConsole()
    {
        MethodBase actualMethod = MethodBase.GetCurrentMethod();
        Debug.Log("La fonction " + actualMethod.Name + " fonctionne correctement");
        Debug.Log("L'objet selectionner est " + Selection.activeGameObject.name);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Rend la fonction "LogConsole" active si un objet est selectionner</returns>
    [MenuItem("Tools/Log Console", true)]
    static bool CheckIfLogConsoleIsValid()
    {
        if (Selection.activeGameObject != null)
            return true; //*true if menu item should be available*//
        else
            return false;
  }
}