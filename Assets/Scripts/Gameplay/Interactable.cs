using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Sprite IconSprite;
    private bool inRange = false;
    protected bool useable = true;
    protected GameObject visualiser;

    protected virtual void Start()
    {

        visualiser = (GameObject)Instantiate(Resources.Load("Prefabs/InteractableVisualiser"), transform.position, Quaternion.identity);
        visualiser.transform.parent = gameObject.transform;
        if (IconSprite != null)
            visualiser.GetComponent<SpriteRenderer>().sprite = IconSprite;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        inRange = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inRange = false;

    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && inRange && useable)
        {
            Interaction();
        }
    }

    protected virtual void Interaction()
    {
        Debug.Log("Default Interaction");
    }

    public virtual void Deactivate()
    {
        visualiser.SetActive(false);
        useable = false;
        gameObject.SetActive(false);
    }
}
