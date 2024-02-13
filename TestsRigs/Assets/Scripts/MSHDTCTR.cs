using DynamicMeshCutter;
using System;
using UnityEngine;

public class MSHDTCTR : MonoBehaviour
{
    private Vector3[] Positions2 = new Vector3[2];

    private double LineLengthAfterKeyUp;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DTOBJ.IsButtonPressed = true;
            //Debug.Log("Нажал кнопку!");
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            DTOBJ.IsButtonPressed = false;

            //Debug.Log("Отжал кнопку!");
                     
            GameObject.Find("MouseCutter").GetComponent<LineRenderer>().GetPositions(Positions2);
            LineLengthAfterKeyUp = Math.Sqrt(Math.Pow(Positions2[1].x - Positions2[0].x, 2) + Math.Pow(Positions2[1].y - Positions2[0].y, 2));

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
