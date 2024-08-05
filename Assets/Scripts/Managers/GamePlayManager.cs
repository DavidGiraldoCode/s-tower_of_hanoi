using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance { get; set; }
    [SerializeField] private GameState so_gameState;
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
}
