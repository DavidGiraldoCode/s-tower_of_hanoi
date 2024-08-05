using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private Vector2 m_pointer;
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

    public void onPick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log(context.ReadValue<float>());
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
    public void onMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_pointer = context.ReadValue<Vector2>();
            //Debug.Log(m_pointer);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(m_pointer);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.point);
                Debug.DrawLine(ray.origin, hit.point);
                //if (SpellInvocationManager.Instance)
                //SpellInvocationManager.Instance.UpdateTracer(hit.point);

                // if(SpellTracerManager.Instance)
                // {
                //     SpellTracerManager.Instance.SetPoint(1, hit.point);
                // }
            }
        }

    }
}
