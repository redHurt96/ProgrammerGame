using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Pan : MonoBehaviour
{
    [Header("Desktop debug")]
    [Tooltip("Use the mouse on desktop?")]
    public bool useMouse = true;

    [Header("Camera control")]
    [Tooltip("Does the script control camera movement?")]
    public bool controlCamera = true;
    [Tooltip("The controlled camera, ignored of controlCamera=false")]
    public Camera cam;

    [Tooltip("Does the script control camera movement?")]
    public bool isCinemachineUse = false;
    [Tooltip("The controlled camera, ignored of controlCamera=false")]
    public Transform cinemachine;

    [Header("UI")]
    [Tooltip("Are touch motions listened to if they are over UI elements?")]
    public bool ignoreUI = false;

    [Header("Bounds")]
    [Tooltip("Is the camera bound to an area?")]
    public bool useBounds;

    public float boundMinX = -150;
    public float boundMaxX = 150;
    public float boundMinY = -150;
    public float boundMaxY = 150;

    Vector2 touch0StartPosition;
    Vector2 touch0LastPosition;

    bool cameraControlEnabled = true;

    bool canUseMouse;
    private Transform _camTransform;

    /// <summary> Has the player at least one finger on the screen? </summary>
    public bool isTouching { get; private set; }

    void Start()
    {
        _camTransform = cam.transform;
        canUseMouse = Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer && Input.mousePresent;
    }

    void Update()
    {
        if (useMouse && canUseMouse)
        {
            UpdateWithMouse();
        }
        else
        {
            UpdateWithTouch();
        }
    }

    void LateUpdate()
    {
        CameraInBounds();
    }

    void UpdateWithMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ignoreUI || !IsPointerOverUIObject())
            {
                touch0StartPosition = Input.mousePosition;
                touch0LastPosition = touch0StartPosition;

                isTouching = true;
            }
        }

        if (Input.GetMouseButton(0) && isTouching)
        {
            Vector2 move = (Vector2)Input.mousePosition - touch0LastPosition;
            touch0LastPosition = Input.mousePosition;

            if (move != Vector2.zero)
            {
                OnSwipe(move);
            }
        }

        if (Input.GetMouseButtonUp(0) && isTouching)
        {
            isTouching = false;
            cameraControlEnabled = true;
        }
    }

    void UpdateWithTouch()
    {
        int touchCount = Input.touches.Length;

        if (touchCount == 1)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {
                        if (ignoreUI || !IsPointerOverUIObject())
                        {
                            touch0StartPosition = touch.position;
                            touch0LastPosition = touch0StartPosition;

                            isTouching = true;
                        }

                        break;
                    }
                case TouchPhase.Moved:
                    {
                        touch0LastPosition = touch.position;

                        if (touch.deltaPosition != Vector2.zero && isTouching)
                        {
                            OnSwipe(touch.deltaPosition);
                        }
                        break;
                    }
                case TouchPhase.Ended:
                    {
                        isTouching = false;
                        cameraControlEnabled = true;
                        break;
                    }
                case TouchPhase.Stationary:
                case TouchPhase.Canceled:
                    break;
            }
        }
        else
        {
            if (isTouching) 
                isTouching = false;

            cameraControlEnabled = true;
        }
    }

    void OnSwipe(Vector2 deltaPosition)
    {
        if (controlCamera && cameraControlEnabled)
        {
            if (cam == null) cam = Camera.main;

            if (isCinemachineUse)
                cam.transform.position -= cam.ScreenToWorldPoint(deltaPosition) - cam.ScreenToWorldPoint(Vector2.zero);
            else
                cinemachine.transform.position -= cam.ScreenToWorldPoint(deltaPosition) - cam.ScreenToWorldPoint(Vector2.zero);

        }
    }

    /// <summary> Checks if the the current input is over canvas UI </summary>
    private bool IsPointerOverUIObject()
    {
        if (EventSystem.current == null) return false;
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    void CameraInBounds()
    {
        if (controlCamera && useBounds && cam != null && cam.orthographic)
        {
            Vector2 margin = cam.ScreenToWorldPoint((Vector2.up * Screen.height / 2) + (Vector2.right * Screen.width / 2)) - cam.ScreenToWorldPoint(Vector2.zero);

            float marginX = margin.x;
            float marginY = margin.y;

            float camMaxX = boundMaxX - marginX;
            float camMaxY = boundMaxY - marginY;
            float camMinX = boundMinX + marginX;
            float camMinY = boundMinY + marginY;

            float camX = Mathf.Clamp(_camTransform.position.x, camMinX, camMaxX);
            float camY = Mathf.Clamp(_camTransform.position.y, camMinY, camMaxY);

            _camTransform.position = new Vector3(camX, camY, _camTransform.position.z);

            if (isCinemachineUse)
                cinemachine.transform.position = new Vector3(camX, camY, cinemachine.transform.position.z);
        }
    }
}
