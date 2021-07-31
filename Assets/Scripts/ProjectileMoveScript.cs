using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveScript : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
