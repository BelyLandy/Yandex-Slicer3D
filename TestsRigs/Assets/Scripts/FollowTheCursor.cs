using UnityEngine;

public class FollowTheCursor : MonoBehaviour
{
    private Vector3 _pos;
    private float _speed = 1f;

    private void Update()
    {
        _pos = Input.mousePosition;
        _pos.z = _speed;
        transform.position = Camera.main.ScreenToWorldPoint(_pos);
    }
}
