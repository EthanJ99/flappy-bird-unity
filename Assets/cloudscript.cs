using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudscript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float spriteOffset;
    public float deadZone = -30;

    // Start is called before the first frame update
    void Start()
    {
        // Random cloud size
        float minScale = 1.2f;
        float maxScale = 3f;
        float newScale = Random.Range(minScale, maxScale);

        transform.localScale  = new Vector3(newScale, newScale, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
            Debug.Log("Deleting cloud!");
        }
    }
}
