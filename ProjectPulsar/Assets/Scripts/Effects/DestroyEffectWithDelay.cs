using UnityEngine;
using System.Collections;

public class DestroyEffectWithDelay : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 1.5f);
    }
}
