using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    // Start is called before the first frame update
    private float startPos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector2(startPos + distance, transform.position.y);
    }
}
