using UnityEngine;

public class moneyAdd : MonoBehaviour
{
    private float playerArea;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        // ����� ������� ������ � ����� Player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Renderer playerMeshRenderer = player.GetComponent<Renderer>();
            if (playerMeshRenderer != null)
            {
                // ������������ "�������" (� ������ ������ ������ ������) ��� ������
                playerArea = playerMeshRenderer.bounds.size.sqrMagnitude;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // ������������ "�������" ��� ������� ������������
        MeshRenderer collisionMeshRenderer = collision.gameObject.GetComponentInChildren<MeshRenderer>();
        if (collisionMeshRenderer != null)
        {
            float collisionArea = collisionMeshRenderer.bounds.size.sqrMagnitude;
            // ����� ������� ������� ������������ �� ������� ������, �������� �� 1000
            float value = (collisionArea / playerArea) * 1000;
            Debug.Log(value);
            // ���������� �������� � PlayerPrefs ��� ������ "coins"
            if (PlayerPrefs.HasKey("coins")) PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + (int)value);
            else PlayerPrefs.SetInt("coins", (int)value);
            PlayerPrefs.Save(); // �� �������� ��������� ��������� PlayerPrefs
        }
        Destroy(collision.gameObject);
    }
}