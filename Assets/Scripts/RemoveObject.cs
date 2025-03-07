using UnityEngine;

public class RemoveObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.SetActive(false);
    }
}
