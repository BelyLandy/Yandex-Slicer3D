using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using UnityEngine.EventSystems;
using DynamicMeshCutter;

public class SlicerUPD : MonoBehaviour, IPointerEnterHandler
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

                //Debug.Log("Получил объект!");
            }
            GameObject.Find("MouseCutter").GetComponent<LineRenderer>().GetPositions(Positions);
            LineLength = Sqrt(Pow(Positions[1].x - Positions[0].x, 2) + Pow(Positions[1].y - Positions[0].y, 2));
        }
    }

    private Vector3[] Positions2 = new Vector3[2];

    private double LineLengthAfterKeyUp;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DTOBJ.IsButtonPressed = true;

            //Debug.Log("Нажал кнопку!");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            DTOBJ.IsButtonPressed = false;

            //Debug.Log("Отжал кнопку!");

            GameObject.Find("MouseCutter").GetComponent<LineRenderer>().GetPositions(Positions2);
            LineLengthAfterKeyUp = Sqrt(Pow(Positions2[1].x - Positions2[0].x, 2) + Pow(Positions2[1].y - Positions2[0].y, 2));

            if (DTOBJ.gameObjects.Count != 0 && LineLengthAfterKeyUp >= DTOBJ.LineLength)
            {
                for (int i = 0; i < DTOBJ.gameObjects.Count; i++)
                {
                    DTOBJ.gameObjects[i].GetComponent<MeshTarget>().enabled = true;
                    //Debug.Log($"{i+1}) {DTOBJ.gameObjects[i].name}");
                }
            }

            if (DTOBJ.gameObjects.Count != 0)
            {
                if (DTOBJ.SlicedObjectName == "Play")
                {
                    // Начать игру.
                    Debug.Log("Start Game!");
                }
                else if (DTOBJ.SlicedObjectName == "Leaderboard")
                {
                    // Ссылка на лидерборд.
                    Debug.Log("LeaderBoard!");
                }
                else if (DTOBJ.SlicedObjectName == "YandexGamesButton")
                {
                    // Ссылка на наши игры.
                    Debug.Log("Yandex Games!");
                }

                //Debug.Log(DTOBJ.SlicedObjectName);
                //DTOBJ.SlicedObjectName = null;
            }

            DTOBJ.gameObjects.Clear();
        }
    }
}
