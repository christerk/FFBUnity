using Cinemachine;
using Fumbbl;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    public Camera Camera;
    public Vector3 mouseSensitivity = new Vector3(1,1,1);
    public Vector2 rotationSpeed = new Vector2(5, 5);
    public GameObject CameraTarget;
    public CinemachineVirtualCamera VCam;

    private Vector3 lastRotatePosition;
    private Vector3 lastPanPosition;
    private Vector3 initialRotateAngles;

    private Vector2 targetRotation;

    #region MonoBehaviour Methods

    private void Start()
    {
        targetRotation = CameraTarget.transform.rotation.eulerAngles;
    }

    private void Update()
    {
        if (VCam != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                lastRotatePosition = Input.mousePosition;
                initialRotateAngles = CameraTarget.transform.rotation.eulerAngles;
            }

            var angles = CameraTarget.transform.rotation.eulerAngles;
            var currentX = angles.x;
            var currentY = angles.y;

            if (Input.GetMouseButton(1))
            {
                Vector3 delta = Input.mousePosition - lastRotatePosition;

                var targetX = MinMax(10, initialRotateAngles.x + (delta.y * mouseSensitivity.y / 100), 90);
                var targetY = (initialRotateAngles.y + (delta.x * mouseSensitivity.x / 100)) % 360;

                if (targetY - currentY > 180)
                {
                    targetY -= 360;
                }

                if (targetY - currentY < -180)
                {
                    targetY += 360;
                }

                targetRotation.x = targetX;
                targetRotation.y = targetY;
            }

            var rotationDistance = Vector3.Distance(angles, targetRotation);
            if (rotationDistance > 0.5) {

                var targetX = targetRotation.x;
                var targetY = targetRotation.y;

                if (targetY - currentY > 180)
                {
                    targetY -= 360;
                }

                if (targetY - currentY < -180)
                {
                    targetY += 360;
                }

                var deltaX = (targetX - currentX) * rotationSpeed.y;
                var deltaY = ((targetY - currentY)%360) * rotationSpeed.x;

                angles.x = currentX + deltaX;
                angles.y = currentY + deltaY;

                var quaternion = Quaternion.Euler(angles);
                CameraTarget.transform.rotation = quaternion;
                //lastRotatePosition = Input.mousePosition;
            } else if (rotationDistance != 0)
            {
                CameraTarget.transform.rotation = Quaternion.Euler(targetRotation);
            }

            if (Input.mouseScrollDelta.y != 0)
            {
                var componentBase = VCam.GetCinemachineComponent(CinemachineCore.Stage.Body);
                if (componentBase is Cinemachine3rdPersonFollow)
                {
                    var distance = (componentBase as Cinemachine3rdPersonFollow).CameraDistance;
                    distance = MinMax(20, distance + Input.mouseScrollDelta.y * mouseSensitivity.z, 300);
                    (componentBase as Cinemachine3rdPersonFollow).CameraDistance = distance;
                }
            }

            if (Input.GetMouseButtonDown(2))
            {
                lastPanPosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(2))
            {
                var src = Input.mousePosition;
                Vector3 screenDelta = Input.mousePosition - lastPanPosition;
                var dst = src + screenDelta;

                var srcRay = Camera.ScreenPointToRay(src);
                var dstRay = Camera.ScreenPointToRay(dst);
                var plane = new Plane(Vector3.up, 0);

                float srcDistance;
                float dstDistance;
                plane.Raycast(srcRay, out srcDistance);
                plane.Raycast(dstRay, out dstDistance);

                var srcHit = srcRay.GetPoint(srcDistance);
                var dstHit = dstRay.GetPoint(dstDistance);

                var worldDelta = dstHit - srcHit;
                var newPosition = CameraTarget.transform.position - worldDelta;
                newPosition.x = MinMax(-200, newPosition.x, 200);
                newPosition.z = MinMax(-100, newPosition.z, 50);
                CameraTarget.transform.position = newPosition;
                
                lastPanPosition = Input.mousePosition;
            }
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            CameraTarget.transform.position = new Vector3(0, 0, 0);
            // CameraTarget.transform.rotation = Quaternion.Euler(90, 0, 0);
            targetRotation = new Vector2(90, 0); //CameraTarget.transform.rotation.eulerAngles;

            var componentBase = VCam.GetCinemachineComponent(CinemachineCore.Stage.Body);
            if (componentBase is Cinemachine3rdPersonFollow)
            {
                (componentBase as Cinemachine3rdPersonFollow).CameraDistance = 138;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (string.Equals("SettingsScene", currentScene))
            {
                SwitchToPreviousScene();
            }
            else
            {
                SwitchToSettingsScene();
            }
        }
    }

    #endregion

    private float MinMax(float min, float val, float max)
    {
        return Math.Min(max, Math.Max(min, val));
    }

    public void SwitchToPreviousScene()
    {
        MainHandler.Instance.SetScene(FFB.Instance.PreviousScene);
    }

    public void SwitchToSettingsScene()
    {
        FFB.Instance.PreviousScene = SceneManager.GetActiveScene().name;
        MainHandler.Instance.SetScene(MainHandler.SceneType.SettingsScene);
    }
}
