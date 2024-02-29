using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private GameObject blocker;
    private bool isPressed;

    void OnTriggerEnter(Collider col)
    {
        if (!isPressed && col.gameObject.tag == "Weight")
        {
            isPressed = true;
            blocker.SetActive(false);
        }
    }
}
