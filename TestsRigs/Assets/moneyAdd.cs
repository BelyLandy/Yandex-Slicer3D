using UnityEngine;

public class moneyAdd : MonoBehaviour
{
    private float playerArea;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        // Найти игровой объект с тегом Player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Renderer playerMeshRenderer = player.GetComponent<Renderer>();
            if (playerMeshRenderer != null)
            {
                // Рассчитываем "площадь" (в данном случае просто размер) для игрока
                playerArea = playerMeshRenderer.bounds.size.sqrMagnitude;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Рассчитываем "площадь" для объекта столкновения
        MeshRenderer collisionMeshRenderer = collision.gameObject.GetComponentInChildren<MeshRenderer>();
        if (collisionMeshRenderer != null)
        {
            float collisionArea = collisionMeshRenderer.bounds.size.sqrMagnitude;
            // Делим площадь объекта столкновения на площадь игрока, умножаем на 1000
            float value = (collisionArea / playerArea) * 1000;
            Debug.Log(value);
            // Записываем значение в PlayerPrefs под ключом "coins"
            if (PlayerPrefs.HasKey("coins")) PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + (int)value);
            else PlayerPrefs.SetInt("coins", (int)value);
            PlayerPrefs.Save(); // Не забудьте сохранить изменения PlayerPrefs
        }
        Destroy(collision.gameObject);
    }
}