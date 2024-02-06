using UnityEngine;

public class UIDD : MonoBehaviour
{
    public string tagToSearch = "UI"; // Тег объектов, которые нужно удалить

    private static bool isCreated = false;

    private void Awake()
    {
        if (!isCreated)
        {
            DontDestroyOnLoad(gameObject);
            isCreated = true;
        }
        else
        {
            DestroyDuplicateObjects();
        }
    }

    private void DestroyDuplicateObjects()
    {
        GameObject[] duplicates = GameObject.FindGameObjectsWithTag(tagToSearch);

        foreach (var duplicate in duplicates)
        {
            if (duplicate != gameObject)
            {
                Destroy(duplicate);
            }
        }
    }
}