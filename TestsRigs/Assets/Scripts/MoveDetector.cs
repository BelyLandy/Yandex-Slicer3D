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
            Debug.Log("����� ������!");
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            DetectObjectToSlice.IsButtonPressed = false;
            DetectObjectToSlice.IsOneDetected = false;

            Debug.Log("����� ������!");

            if (DetectObjectToSlice.SlicedObjectName != null)
            {
                if (DetectObjectToSlice.SlicedObjectName == "Play")
                {
                    // ������ ����.
                }
                else if (DetectObjectToSlice.SlicedObjectName == "Leaderboard")
                {
                    // ������ �� ���������.
                }
                else if (DetectObjectToSlice.SlicedObjectName == "YandexGamesButton")
                {
                    // ������ �� ���� ����.
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
    //        Debug.Log("����� ������!");
    //    }      
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    if (eventData.button == 0)
    //    {
    //        DetectObjectToSlice.IsButtonPressed = false;
    //        DetectObjectToSlice.IsOneDetected = false;

    //        Debug.Log("����� ������!");

    //        if (DetectObjectToSlice.SlicedObjectName != null)
    //        {
    //            if (DetectObjectToSlice.SlicedObjectName == "Play")
    //            {
    //                // ������ ����.
    //            }
    //            else if (DetectObjectToSlice.SlicedObjectName == "Leaderboard")
    //            {
    //                // ������ �� ���������.
    //            }
    //            else if (DetectObjectToSlice.SlicedObjectName == "YandexGamesButton")
    //            {
    //                // ������ �� ���� ����.
    //            }

    //            Debug.Log(DetectObjectToSlice.SlicedObjectName);
    //            DetectObjectToSlice.SlicedObjectName = null;
    //        }
    //    }
    //}
}
