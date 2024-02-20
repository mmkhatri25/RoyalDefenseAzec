using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AdditionalFunctionaning : MonoBehaviour
{
    public static AdditionalFunctionaning instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void onTutorial()
    {
        Time.timeScale = 0f;
    }
    public void onTutorialClose()
    {
        Time.timeScale = 1f;
    }
    public float scrollSpeed = 8.0f;

    private bool isMovingLeft;
    private bool isMovingRight;

    public bool isPressed;
    public int direction;

    
    private void Update()
    {
        if (isPressed)
        {
            if (direction == -1 && Camera.main.transform.position.x <= 0.1f)
                return;
            if (direction == 1 && Camera.main.transform.position.x >= 15f)
                return;
            float newPosition = Camera.main.transform.position.x + direction * scrollSpeed * Time.deltaTime;
            //float newPosition = Mathf.Clamp(Camera.main.transform.position.x + direction * scrollSpeed * Time.deltaTime, -0.1f, -10f);

            // Update the camera position
            Camera.main.transform.position = new Vector3(newPosition, Camera.main.transform.position.y, Camera.main.transform.position.z);

        }
    }

    public void MoveCamera(int direction1, bool isPressed1)
    {
        isPressed = isPressed1;
        direction = direction1;
        // Calculate the new position based on the input and speed
        
    }
}
