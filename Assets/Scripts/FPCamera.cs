using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Transform cameraTransform;
    public float normalHeight = 1f;

    private float xRotation = 0f;
    private Vector3 cameraOriginalPosition;
    private Vector3 cameraCrouchPosition;
    private Vector3 cameraVelocity = Vector3.zero;

    //public GameObject youWinUI;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //if (youWinUI.activeSelf)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}
        cameraOriginalPosition = cameraTransform.localPosition;

        // match the player's rotation
        xRotation = playerBody.localEulerAngles.x;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private IEnumerator AdjustCameraPosition(Vector3 targetPosition)
    {
        float timer = 0f;

        while (timer <= 1f)
        {
            //cameraTransform.localPosition = Vector3.SmoothDamp(cameraTransform.localPosition, targetPosition, ref cameraVelocity);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}