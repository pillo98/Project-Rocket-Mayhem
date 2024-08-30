using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    [SerializeField] private GameObject BrokenVariant;
    public void BreakObject()
    {
        Instantiate(BrokenVariant, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
