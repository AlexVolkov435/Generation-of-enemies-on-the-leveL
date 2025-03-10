using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _rotationeSpeed = 10;
    private Vector3 _direction;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_direction),  Time.fixedDeltaTime * _rotationeSpeed);
    }

    public void Init(Vector3 derection)
    {
        _direction = derection;
    }
}
