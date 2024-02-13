using DynamicMeshCutter;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DTOBJ : MonoBehaviour, IPointerEnterHandler
{
    public static bool IsButtonPressed;

    public static string SlicedObjectName;

    public static List<GameObject> gameObjects = new();

    public static double LineLength;
    public static Vector3[] Positions = new Vector3[2];

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsButtonPressed)
        {
            if (!gameObjects.Contains(gameObject))
            {
                gameObjects.Add(gameObject);
                GameObject.Find("MouseCutter").GetComponent<LineRenderer>().GetPositions(Positions);
                LineLength = Math.Sqrt(Math.Pow(Positions[1].x - Positions[0].x, 2) + Math.Pow(Positions[1].y - Positions[0].y, 2));
                //Debug.Log("Получил объект!");
            }
            
        }      
    }
}
