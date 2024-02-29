using DynamicMeshCutter;
using RootMotion;
using System;
using UnityEngine;

public class MSHDTCTR : MonoBehaviour
{
    private Vector3[] Positions2 = new Vector3[2];

    private double LineLengthAfterKeyUp;

    public static bool isNeedEventHappened = false;

    [Header("Hit Sounds")]
    [SerializeField] private AudioClip[] audioClips;

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
            LineLengthAfterKeyUp = Math.Sqrt(Math.Pow(Positions2[1].x - Positions2[0].x, 2) + Math.Pow(Positions2[1].y - Positions2[0].y, 2));

            if (DTOBJ.gameObjects.Count != 0 && LineLengthAfterKeyUp >= DTOBJ.LineLength)
            {
                for (int i = 0; i < DTOBJ.gameObjects.Count; i++)
                {
                    DTOBJ.gameObjects[i].GetComponent<MeshTarget>().enabled = true;
                    //Debug.Log($"{i+1}) {DTOBJ.gameObjects[i].name}");
                }

                if (DTOBJ.SlicedObjectName == "Player")
                {
                    if (audioClips != null && audioClips.Length == 2)
                    {
                        GetComponent<AudioSource>().clip = audioClips[UnityEngine.Random.Range(0, 2)];
                        GetComponent<AudioSource>().Play();
                    }                 
                }
                else
                {
                    if (audioClips != null && audioClips.Length == 1)
                    {
                        GetComponent<AudioSource>().clip = audioClips[0];
                        GetComponent<AudioSource>().Play();
                    }
                }

                if (DTOBJ.IsAnObjectGot && isNeedEventHappened == false)
                {
                    if (DTOBJ.SlicedObjectName == "Play")
                    {
                        // Начать игру.
                        
                            GameObject.Find("Cutout").GetComponent<RectTransform>().anchoredPosition = new Vector2(100, -232);
                        
                   
                        Loader.scene = Loader.Scene.LoadingScreen;
                        Debug.Log("Start Game!");
                    }
                    else if (DTOBJ.SlicedObjectName == "Leaderboard")
                    {
                        // Ссылка на лидерборд.
                        if (GameObject.Find("Cutout"))
                        {
                            GameObject.Find("Cutout").GetComponent<RectTransform>().anchoredPosition = new Vector2(-392, -296);
                        }

                        Debug.Log("LeaderBoard!");
                    }
                    else if (DTOBJ.SlicedObjectName == "YandexGamesButton")
                    {
                        // Ссылка на наши игры.
                        if (GameObject.Find("Cutout"))
                        {
                            GameObject.Find("Cutout").GetComponent<RectTransform>().anchoredPosition = new Vector2(585, -288);
                        }

                        Loader.scene = Loader.Scene.YandexGames;
                        Debug.Log("Yandex Games!");
                    }
                    
                    if (GameObject.Find("Mask"))
                    {
                        GameObject.Find("Mask").GetComponent<Animator>().enabled = true;
                    }

                    isNeedEventHappened = true;
                    
                    //Debug.Log(DTOBJ.SlicedObjectName);
                    
                }
                DTOBJ.SlicedObjectName = "";              
                DTOBJ.IsAnObjectGot = false;
            }          
            else if (LineLengthAfterKeyUp < DTOBJ.LineLength)
            {
                DTOBJ.IsAnObjectGot = false;
            }

            DTOBJ.gameObjects.Clear();
        }
    }

}
