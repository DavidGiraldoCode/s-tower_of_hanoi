using UnityEngine;
using TMPro;

public class MovesCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text m_guiMovesCounter;
    [SerializeField] private GameState so_gameState;
    // Start is called before the first frame update
    void Start()
    {
        m_guiMovesCounter.text = "Moves: " + so_gameState.MovesCounter;

    }

    // Update is called once per frame
    void Update()
    {
         m_guiMovesCounter.text = "Moves: " + so_gameState.MovesCounter;
    }
}
