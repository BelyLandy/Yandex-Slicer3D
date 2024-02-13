using DynamicMeshCutter;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectObjectToSlice : MonoBehaviour
{
    public static bool IsOneDetected;
    public static bool IsButtonPressed;

    public static string SlicedObjectName;

    private void OnMouseOver()
    {
        if (!IsOneDetected && IsButtonPressed)
        {
            gameObject.GetComponent<MeshTarget>().enabled = true;
            SlicedObjectName = gameObject.name;
            IsOneDetected = true;
            Debug.Log("Получил объект!");
        }
        Debug.Log("MouseEnter");
    }
}
