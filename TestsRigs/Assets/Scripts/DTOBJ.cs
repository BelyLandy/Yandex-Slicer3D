using DynamicMeshCutter;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DTOBJ : MonoBehaviour, IPointerEnterHandler
{
    public static bool IsButtonPressed;

    public static string SlicedObjectName;

    public static bool IsAnObjectGot;

    public static List<GameObject> gameObjects = new();

    public static double LineLength;
    public static Vector3[] Positions = new Vector3[2];   

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter");      
        if (IsButtonPressed)
        {
            if (IsAnObjectGot)
            {
                if (SlicedObjectName == gameObject.name)
                {
                    gameObjects.Add(gameObject);
                }
            }

            if ((gameObject.name == "Play" || gameObject.name == "Leaderboard" || gameObject.name == "YandexGamesButton") && !IsAnObjectGot)
            {
                gameObjects.Add(gameObject);
                IsAnObjectGot = true;
                SlicedObjectName = gameObject.name;
                //Debug.Log("Меню кнопка получена!");
            }

            if (gameObject.name == "Player")
            {
                SlicedObjectName = gameObject.name;
            }

            if (!gameObjects.Contains(gameObject) && !IsAnObjectGot)
            {
                gameObjects.Add(gameObject);
                
                //Debug.Log("Получил объект!");
            }
            GameObject.Find("MouseCutter").GetComponent<LineRenderer>().GetPositions(Positions);
            LineLength = Math.Sqrt(Math.Pow(Positions[1].x - Positions[0].x, 2) + Math.Pow(Positions[1].y - Positions[0].y, 2));
        }      
    }
}
