using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector2 offset;

    void FixedUpdate()
    {
        Vector2 desiredPosition = new Vector2(target.position.x, -6.88f) + offset;
        Vector2 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        float xScale = Mathf.Abs(target.transform.rotation.normalized.z - 1);
        this.transform.localScale = new Vector3(xScale * this.transform.localScale.z, this.transform.localScale.y, this.transform.localScale.z);
    }
}
