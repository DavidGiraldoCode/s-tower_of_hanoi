using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiskController : MonoBehaviour
{
    [SerializeField] private int m_diskNumber = -1;
    private int m_curreRrod = 1; //Center ROD
    public int CurrentRod {get => m_curreRrod; set => m_curreRrod = value;}
    private float scale = 0.25f;
    public int DiskNumber { get => m_diskNumber; }

    private void Start()
    {
        if (m_diskNumber > -1)
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * (m_diskNumber + 0.2f) * scale, gameObject.transform.localScale.y, gameObject.transform.localScale.z * (m_diskNumber + 0.2f) * scale);
    }
}
