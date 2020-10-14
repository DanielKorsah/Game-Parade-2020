using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBasedSortingLayer : MonoBehaviour
{
    [SerializeField] private float offset = 0;
    [SerializeField] int sortingOrderBase = 5000;
    private Renderer renderer;



    void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        renderer.sortingOrder = (int)(sortingOrderBase - (transform.position.y - offset));
    }
}
