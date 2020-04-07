using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform focusTarget = null;
    [SerializeField]
    private float height = 10f;
    [SerializeField]
    private float distance = 17f;
    [SerializeField]
    private float angle = 60f;
    [SerializeField]
    private float smoothSpeed = .25f;
    [SerializeField]
    private float centerOffset = 0f;
    /*First person view too many glitches for now*/
    //[SerializeField]
    //private Camera secondaryCamera;

    private Camera mainCamera;
    private Vector3 refVelocity;
    private Vector3 centerOffsetPosition;
    //private bool isDefaultPOV;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        //isDefaultPOV = true;
        Cursor.lockState = CursorLockMode.Locked;
        CameraFollow(target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (focusTarget == null)
            CameraFollow(target);
        else
            CameraFollow(focusTarget);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        /*First person view too many glitches for now*/
        //else if (Input.GetKeyDown(KeyCode.V))
        //{
        //    isDefaultPOV = !isDefaultPOV;
        //    mainCamera.enabled = isDefaultPOV;
        //    secondaryCamera.enabled = !isDefaultPOV;
        //}
    }

    private void CameraFollow(Transform target)
    {
        if (!target)
            return;

        //Setup Camera transform basics
        Vector3 worldPosition = (Vector3.forward * -distance) + (Vector3.up * height);
        Vector3 worldRotation = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;

        //Force target position horizontal flat
        Vector3 flatTargetPosition = target.position;
        flatTargetPosition.y = 0f;

        //Apply all of it to the camera transform
        Vector3 finalPosition = flatTargetPosition + worldRotation;
        centerOffsetPosition = new Vector3(0, centerOffset, 0);
        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, smoothSpeed);
        transform.LookAt(target.position + centerOffsetPosition);
    }

    public void ResetDefaultCameraSettings()
    {
        focusTarget = null;
        height = 10f;
        distance = 17f;
        angle = 60f;
        smoothSpeed = .25f;
        centerOffset = 0f;
    }

    public void SetCustomCameraSettings(Transform focusTarget, float height, float distance, float angle, float smoothSpeed, float centerOffset)
    {
        this.focusTarget = focusTarget;
        this.height = height;
        this.distance = distance;
        this.angle = angle;
        this.smoothSpeed = smoothSpeed;
        this.centerOffset = centerOffset;
    }
}
