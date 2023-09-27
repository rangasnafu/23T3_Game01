using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private void Update()
    {
        Vector3 moveDirection = Vector3.up;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
