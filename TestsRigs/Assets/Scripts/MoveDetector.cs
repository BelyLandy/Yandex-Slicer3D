using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MoveDetector : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetectObjectToSlice.IsButtonPressed = true;
            Debug.Log("Нажал кнопку!");
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            DetectObjectToSlice.IsButtonPressed = false;
            DetectObjectToSlice.IsOneDetected = false;

            Debug.Log("Отжал кнопку!");

            if (DetectObjectToSlice.SlicedObjectName != null)
            {
                if (DetectObjectToSlice.SlicedObjectName == "Play")
                {
                    // Начать игру.
                }
                else if (DetectObjectToSlice.SlicedObjectName == "Leaderboard")
                {
                    // Ссылка на лидерборд.
                }
                else if (DetectObjectToSlice.SlicedObjectName == "YandexGamesButton")
                {
                    // Ссылка на наши игры.
                }

                Debug.Log(DetectObjectToSlice.SlicedObjectName);
                DetectObjectToSlice.SlicedObjectName = null;
            }
        }
    }


    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    if (eventData.button == 0)
    //    {
    //        DetectObjectToSlice.IsButtonPressed = true;
    //        Debug.Log("Нажал кнопку!");
    //    }      
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    if (eventData.button == 0)
    //    {
    //        DetectObjectToSlice.IsButtonPressed = false;
    //        DetectObjectToSlice.IsOneDetected = false;

    //        Debug.Log("Отжал кнопку!");

    //        if (DetectObjectToSlice.SlicedObjectName != null)
    //        {
    //            if (DetectObjectToSlice.SlicedObjectName == "Play")
    //            {
    //                // Начать игру.
    //            }
    //            else if (DetectObjectToSlice.SlicedObjectName == "Leaderboard")
    //            {
    //                // Ссылка на лидерборд.
    //            }
    //            else if (DetectObjectToSlice.SlicedObjectName == "YandexGamesButton")
    //            {
    //                // Ссылка на наши игры.
    //            }

    //            Debug.Log(DetectObjectToSlice.SlicedObjectName);
    //            DetectObjectToSlice.SlicedObjectName = null;
    //        }
    //    }
    //}
}
