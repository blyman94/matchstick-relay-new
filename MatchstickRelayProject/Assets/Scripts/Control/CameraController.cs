using UnityEngine;
using Cinemachine;

/// <summary>
/// Rotates the CameraFollowTarget to create look-ahead behavior in the
/// direction the player is moving.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Transform representing the camera's follow target.
    /// </summary>
    [Tooltip("Transform representing the camera's follow target.")]
    [SerializeField] private Transform cameraFollowTarget;

    /// <summary>
    /// The scene's main camera.
    /// </summary>
    [Tooltip("The scene's main camera.")]
    [SerializeField] private Camera mainCamera;

    /// <summary>
    /// The virtual camera following the player.
    /// </summary>
    [Tooltip("The virtual camera following the player.")]
    [SerializeField] private CinemachineVirtualCamera playerFollowCam;

    /// <summary>
    /// The framing transposer of the active virtual camera.
    /// </summary>
    private CinemachineFramingTransposer framingTransposer;

    /// <summary>
    /// Start position of the framingTransposer's tracked point
    /// </summary>
    private Vector2 startPos;

    /// <summary>
    /// Float representing the location of the virtual camera deadzone's
    /// bottom bound. Location is in screen space.
    /// </summary>
    private float bottomBound;

    /// <summary>
    /// Float representing the location of the virtual camera deadzone's
    /// left bound. Location is in screen space.
    /// </summary>
    private float leftBound;

    /// <summary>
    /// Float representing the location of the left virtual camera deadzone's
    /// right bound. Location is in screen space.
    /// </summary>
    private float rightBound;

    /// <summary>
    /// Float representing the location of the left virtual camera deadzone's
    /// top bound. Location is in screen space.
    /// </summary>
    private float topBound;

    #region Monobehaviour Methods
    private void Start()
    {
        framingTransposer =
            playerFollowCam.GetCinemachineComponent<CinemachineFramingTransposer>();
        startPos =
            new Vector2(mainCamera.WorldToScreenPoint(framingTransposer.TrackedPoint).x,
            mainCamera.WorldToScreenPoint(framingTransposer.TrackedPoint).y);

        CalculateDeadzoneBorders();
        LookForward();
    }
    private void Update()
    {
        float trackedX =
            mainCamera.WorldToScreenPoint(framingTransposer.TrackedPoint).x;
        float trackedY =
            mainCamera.WorldToScreenPoint(framingTransposer.TrackedPoint).y;

        if (trackedX <= leftBound)
        {
            LookBackward();
        }
        else if (trackedX >= rightBound)
        {
            LookForward();
        }
    }
    #endregion

    /// <summary>
    /// Calculates the borders of the virtual camera's deadzone, which will
    /// inform this script to change the rotation of the CameraFollowTarget.
    /// </summary>
    private void CalculateDeadzoneBorders()
    {
        float verticalBorderDelta = framingTransposer.m_DeadZoneHeight * 0.5f;
        float horizontalBorderDelta = framingTransposer.m_DeadZoneWidth * 0.5f;

        bottomBound =
            startPos.y - (verticalBorderDelta * mainCamera.pixelHeight);
        topBound =
            startPos.y + (verticalBorderDelta * mainCamera.pixelHeight);

        leftBound =
            startPos.x - (horizontalBorderDelta * mainCamera.pixelWidth);
        rightBound =
            startPos.x + (horizontalBorderDelta * mainCamera.pixelWidth);
    }

    /// <summary>
    /// Rotates the CameraFollowTarget such that the match is centered in the
    /// left-hand corner of the screen.
    /// </summary>
    private void LookForward()
    {
        Quaternion forwardLookRotation = Quaternion.identity;
        if (cameraFollowTarget.rotation != forwardLookRotation)
        {
            cameraFollowTarget.rotation = forwardLookRotation;
        }     
    }

    /// <summary>
    /// Rotates the CameraFollowTarget such that the match is centered in the
    /// right-hand corner of the screen.
    /// </summary>
    private void LookBackward()
    {
        Quaternion backwardLookRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        if (cameraFollowTarget.rotation != backwardLookRotation)
        {
            cameraFollowTarget.rotation = backwardLookRotation;
        }
    }
}
