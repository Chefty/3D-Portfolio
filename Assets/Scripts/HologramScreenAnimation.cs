using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;

public class HologramScreenAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private TopDownCamera topDownCamera;
    private WaitForSeconds delay;

    private void Start()
    {
        topDownCamera = Camera.main.GetComponent<TopDownCamera>();
        delay = new WaitForSeconds(.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.CompareTag("Resume") && animator != null)
        {
            animator.SetBool("Show", true);
            topDownCamera.SetCustomCameraSettings(animator.transform, 6f, 12f, 90f, .5f, 3f);
            StartCoroutine(SlowDownCar(other.gameObject));
        }
        else if (other.CompareTag("Player") && this.CompareTag("Projects") && animator != null)
        {
            animator.SetBool("Show", true);
            topDownCamera.SetCustomCameraSettings(animator.transform, 5f, 23f, 0f, .5f, 3f);
        }
        else if (other.CompareTag("Player") && this.CompareTag("Project") && animator != null)
        {
            int projectValue = int.Parse(gameObject.name.Substring(gameObject.name.Length - 1));
            animator.SetInteger("ProjectValue", projectValue);
            StartCoroutine(SlowDownCar(other.gameObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && this.CompareTag("Resume") && animator != null)
        {
            animator.SetBool("Show", false);
            topDownCamera.ResetDefaultCameraSettings();
        }
        else if (other.CompareTag("Player") && this.CompareTag("Projects") && animator != null)
        {
            animator.SetBool("Show", false);
            topDownCamera.ResetDefaultCameraSettings();
        }
        else if (other.CompareTag("Player") && this.CompareTag("Project") && animator != null)
        {
            animator.SetInteger("ProjectValue", 0);
        }
    }

    private IEnumerator SlowDownCar(GameObject vehicle)
    {
        var wheelVehicle = vehicle.GetComponentInParent<WheelVehicle>();

        if (wheelVehicle)
        {
            wheelVehicle.Handbrake = true;
            yield return delay;
            wheelVehicle.Handbrake = false;
        }
    }
}
