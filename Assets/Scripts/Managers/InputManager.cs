using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private Vector2 m_pointer;
    private InputAction m_mouse;
    private void Awake()
    {
        if (!Instance || Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {

    }

    public void onPick(InputAction.CallbackContext context)
    {

        Debug.Log(context.ReadValue<float>());
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log(hit.collider.gameObject.name);
            Rigidbody selectedDiskRB;
            if (!hit.collider) return;
            if (!hit.collider.gameObject.TryGetComponent<Rigidbody>(out selectedDiskRB)) return;
            StartCoroutine(DragUpdate(selectedDiskRB, context));

        }

    }
    //TODO WIP

    private IEnumerator DragUpdate(Rigidbody selectedDisk, InputAction.CallbackContext context)
    {
        Vector3 initialPosition = selectedDisk.position;
        Vector3 movementPlanePosition = new Vector3(0.01f, 0.01f, 1.0f);//selectedDisk.position;
        float distanceToCamera = Vector3.Distance(movementPlanePosition, Camera.main.transform.position);
        while (context.ReadValue<float>() == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Vector3 point = ray.GetPoint(distanceToCamera);
            Vector3 direction = point - selectedDisk.transform.position;
            selectedDisk.velocity = direction * 2.5f;
            yield return new WaitForFixedUpdate();
        }
        if (context.ReadValue<float>() == 0)
        {

            if (GamePlayManager.Instance)
            {
                if (GamePlayManager.Instance.hoverRod != null)
                {
                    selectedDisk.gameObject.transform.position = new Vector3(GamePlayManager.Instance.hoverRod.transform.position.x, 1.0f, GamePlayManager.Instance.hoverRod.transform.position.z);
                    selectedDisk.gameObject.transform.rotation = Quaternion.identity;
                }
                else
                {
                    selectedDisk.gameObject.transform.position = initialPosition;
                    selectedDisk.gameObject.transform.rotation = Quaternion.identity;
                }

            }

        }
    }

    //TODO
    public void onMove(InputAction.CallbackContext context)
    {

    }

}
