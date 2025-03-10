using UnityEngine;

public class Removal : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.SetActive(false);
    }
}
