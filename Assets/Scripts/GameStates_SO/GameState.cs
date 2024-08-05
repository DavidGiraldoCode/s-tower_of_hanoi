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
    private List<Stack<int>> m_rods = new List<Stack<int>>();
    private Stack<int> m_initialStack = new Stack<int>();
    [SerializeField] private int m_diskOnGame = 5;

    public void SetUpGame()
    {
        m_rods.Add(m_rodLeft);
        m_rods.Add(m_rodCenter);
        m_rods.Add(m_rodRight);

        m_initialStack = m_rods[0];
        FindUpTheRod(m_initialStack, m_diskOnGame);
    }

    public void FindUpTheRod(Stack<int> rod, int diskCount)
    {
        for (int i = (diskCount - 1); i >= 0; i--)
        {
            rod.Push(i);
        }
    }

    //TODO
    /*
    InitialStack
    */
    private int m_currentDisk = -1;
    public int CurrentDisk { get => m_currentDisk; set => m_currentDisk = value; }
}
