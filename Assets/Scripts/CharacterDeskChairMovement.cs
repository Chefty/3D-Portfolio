using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDeskChairMovement : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 100.0f;
    public float boost = 10.0f;
    public float brake = 10f;
    public Rigidbody rigidbody;
    public ParticleSystem fart;

    private Vector3 moveDirection = Vector3.zero;
    private WaitForSeconds boostDelay;
    private bool isBoosted = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        boostDelay = new WaitForSeconds(2f);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!fart.isPlaying)
                fart.Play();
            rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.AddForce(-brake * rigidbody.velocity);
        }
        else
            if (fart.isPlaying)
                fart.Stop();
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(BoostCo());
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0, Space.World);
    }

    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    private IEnumerator BoostCo()
    {
        if (isBoosted != true)
        {
            rigidbody.AddForce(transform.forward * boost, ForceMode.Impulse);
            isBoosted = true;
            yield return boostDelay;
            isBoosted = false;
        }
        else 
            yield return null;
    }
}
