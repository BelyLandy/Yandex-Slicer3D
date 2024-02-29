using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rel : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
