using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBasedSortingLayer : MonoBehaviour
{
    [SerializeField] private float offset = 0;
    [SerializeField] int sortingOrderBase = 5000;
    [SerializeField] bool staticObject = false;
    [SerializeField] int order;
    private Renderer renderer;

    void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        order = (int)(sortingOrderBase - (transform.position.y * 10 - offset));
        renderer.sortingOrder = order;
        if (staticObject)
            Destroy(this);
    }
}
