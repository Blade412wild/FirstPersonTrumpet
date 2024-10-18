using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum GameState { listenForData, dontListenForData }
    private GameState gameState = GameState.dontListenForData;

    public OSCManager oscManager;

    public Apple apple;


    // Start is called before the first frame update
    void Start()
    {
        apple = new Apple(100);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            apple.TakeABite();
        }
    }

    private void CheckGameState()
    {

    }










}
