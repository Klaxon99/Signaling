using UnityEngine;

public class OpenTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    private bool _isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isOpen == false)
        {
            _door.Open();
            _isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isOpen)
        {
            _isOpen = false;
            _door.Close();
        }
    }
}