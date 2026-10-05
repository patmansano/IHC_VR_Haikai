using UnityEngine;

public class FanRotation : MonoBehaviour
{
    [SerializeField] private float speed = 100f;

    void Update()
    {
        transform.Rotate(
            0f,
            speed * Time.deltaTime,
            0f,
            Space.Self
        );
    }
}
