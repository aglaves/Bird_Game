using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ShadowEffect : MonoBehaviour
{
    GameObject shadow;
    public Vector3 offset = new Vector3(.5f, -.5f);
    public Material shadowMaterial;
    private SpriteRenderer shadowRenderer;
    private SpriteRenderer mainSpriteRenderer;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        shadow = new GameObject("Shadow");
        shadow.transform.parent = transform;
        shadow.transform.position = transform.position + offset;
        //shadow.transform.localRotation = Quaternion.identity;

        mainSpriteRenderer = transform.Find("Main").GetComponent<SpriteRenderer>();
        shadowRenderer = shadow.AddComponent<SpriteRenderer>();
        
        shadowRenderer.material = shadowMaterial;
        shadowRenderer.sortingLayerName = mainSpriteRenderer.sortingLayerName;
        shadowRenderer.sortingOrder = mainSpriteRenderer.sortingOrder - 1;
        lastPosition = new Vector3(transform.position.x, transform.position.y);

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (transform.position.x != lastPosition.x || transform.position.y != lastPosition.y)
            offset = new Vector3(offset.x - .01f, offset.y + .01f);

        shadow.transform.position = transform.position + offset;
        shadowRenderer.sprite = mainSpriteRenderer.sprite;
        Debug.Log("Local Rotation: " + transform.localRotation);

        lastPosition = new Vector3(transform.position.x, transform.position.y);
    }
}
