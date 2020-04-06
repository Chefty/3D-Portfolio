using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;
using UnityEngine.SceneManagement;

public class ComputerInputs : MonoBehaviour
{
    public GameObject fakeCursor;
    
    private RectTransform fakeScreenRectTransform;
    private Vector3[] fakeScreenBoundaries = new Vector3[4];
    private float boundOffset = .01f;
    private DigitalGlitch digitalGlitch;
    private AnalogGlitch analogGlitch;
    private Camera camera;

    // Start is called before the first frame update
    void OnEnable()
    {
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Debug.Log("ENABLED: " + Cursor.lockState +" - " + Cursor.visible);
        fakeScreenRectTransform = gameObject.GetComponent<RectTransform>();
        fakeScreenRectTransform.GetWorldCorners(fakeScreenBoundaries);
        digitalGlitch = camera.GetComponent<DigitalGlitch>();
        analogGlitch = camera.GetComponent<AnalogGlitch>();
    }

    // Update is called once per frame
    void Update()
    {
        FakeCursorMove();
    }

    public void FakeCursorMove()
    {
        Vector2 pos;
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(fakeScreenRectTransform, Input.mousePosition, Camera.main, out pos);
        
        Vector3 clampedPosition = gameObject.transform.TransformPoint(pos);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, fakeScreenBoundaries[3].x + boundOffset, fakeScreenBoundaries[0].x - boundOffset);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, fakeScreenBoundaries[0].y + boundOffset, fakeScreenBoundaries[1].y - boundOffset);

        fakeCursor.transform.position = clampedPosition;
    }

    public void LoadPortfolioScene()
    {
        StartCoroutine(LoadPortfolioSceneCo(2f));
    }

    private IEnumerator LoadPortfolioSceneCo(float duration)
    {
        var value = 0f;
        float timer = 0f;
        digitalGlitch.enabled = true;
        analogGlitch.enabled = true;
        while (timer <= duration)
        {
            //Count the other direction.  Its simpler. Or you can do (10-timer) in your
            //SmoothStep Calculation
            value = Mathf.SmoothStep(0, .5f, timer / duration);
            digitalGlitch.intensity = value;
            analogGlitch.scanLineJitter = value;
            analogGlitch.verticalJump = value;
            analogGlitch.horizontalShake = value;
            analogGlitch.colorDrift = value;
            //Divide by 10 to put the timer back in the range of SmoothStep.
            timer += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(1);
        yield return null;
    }
}
