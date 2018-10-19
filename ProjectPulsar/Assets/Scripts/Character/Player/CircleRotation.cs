using UnityEngine;
using System.Collections;

public class CircleRotation : MonoBehaviour
{
    void Update()
    {
        if (gameObject.tag == "Ring1Sprite")
            transform.Rotate(1, 0, 0);
        if (gameObject.tag == "Ring2Sprite")
            transform.Rotate(0, 1, 0);
    }
}
