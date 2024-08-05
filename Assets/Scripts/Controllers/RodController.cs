using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodController : MonoBehaviour
{
    [SerializeField] private int m_rodID;
    private void OnTriggerEnter(Collider other)
    {
        DiskController disk;
        if (!other.gameObject.TryGetComponent<DiskController>(out disk)) return;
        //Debug.Log(disk.DiskNumber);
        if (GamePlayManager.Instance)
        {
            GamePlayManager.Instance.hoverRod = gameObject;
            GamePlayManager.Instance.TryToAddDisk(disk.DiskNumber, m_rodID);
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (GamePlayManager.Instance)
            GamePlayManager.Instance.hoverRod = null;
    }
}
