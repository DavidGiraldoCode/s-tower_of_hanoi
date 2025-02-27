using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance { get; set; }
    [SerializeField] private GameState so_gameState;
    public GameObject hoverRod;
    private void Awake()
    {
        if (!Instance || Instance != this)
        {
            Instance = this;
            try
            {
                if (so_gameState == null)
                    throw new System.ArgumentNullException();
            }
            catch
            {
                Debug.LogError("Add the GameState Scriptable Object on the GamePlayManager");
            }
        }
        else
        {
            Destroy(gameObject);
        }


    }

    void Start()
    {

        so_gameState.SetUpGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RegisterMover()
    {
        so_gameState.MovesCounter++;
    }
    public bool TryToAddDisk(int disNumber, int fromRodID, int toRodID)
    {
        so_gameState.CurrentDisk = disNumber;
        if (so_gameState.rodsList[toRodID].Count == 0)
        {
            so_gameState.rodsList[toRodID].Push(disNumber);
            so_gameState.rodsList[fromRodID].Pop();
            return true;
        }

        if (so_gameState.rodsList[toRodID].Peek() < so_gameState.CurrentDisk) return false;

        so_gameState.rodsList[toRodID].Push(disNumber);
        so_gameState.rodsList[fromRodID].Pop();
        so_gameState.CurrentDisk = -1;

        return true;
    }
}
