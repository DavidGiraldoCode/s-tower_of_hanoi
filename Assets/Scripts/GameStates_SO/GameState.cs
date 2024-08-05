using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This ScriptableObject hold the state of the entire game
/// </summary>
[CreateAssetMenu(fileName = "GameState", menuName = "GameState", order = 0)]
public class GameState : ScriptableObject
{
    private Stack<int> m_rodLeft = new Stack<int>();
    private Stack<int> m_rodCenter = new Stack<int>();
    private Stack<int> m_rodRight = new Stack<int>();
    public List<Stack<int>> rodsList = new List<Stack<int>>();
    private Stack<int> m_initialStack = new Stack<int>();
    [SerializeField] private int m_diskOnGame = 5;
    private int m_movesCounter = 0;
    public int MovesCounter { get => m_movesCounter; set => m_movesCounter = value; }
    private int m_currentDisk = -1;
    public int CurrentDisk { get => m_currentDisk; set => m_currentDisk = value; }

    public void SetUpGame()
    {
        MovesCounter = 0;
        rodsList.Add(m_rodLeft);
        rodsList.Add(m_rodCenter);
        rodsList.Add(m_rodRight);

        m_initialStack = rodsList[1]; //Center
        FillUpTheRod(m_initialStack, m_diskOnGame);

    }

    public void FillUpTheRod(Stack<int> rod, int diskCount)
    {
        for (int i = (diskCount - 1); i >= 0; i--)
        {
            rod.Push(i);
        }
    }

}
