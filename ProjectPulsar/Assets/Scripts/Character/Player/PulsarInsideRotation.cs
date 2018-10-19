using UnityEngine;
using System.Collections;

public class PulsarInsideRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * -4);
    }
}
