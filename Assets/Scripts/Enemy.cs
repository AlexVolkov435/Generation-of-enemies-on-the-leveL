using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _derectionRandomX = 0;
    private float _derectionRandomZ = 0.1f;

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(new Vector3(_derectionRandomX, 0, _derectionRandomZ));
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(_derectionRandomX, 0, _derectionRandomZ)),  Time.deltaTime * 10);
    }
}
