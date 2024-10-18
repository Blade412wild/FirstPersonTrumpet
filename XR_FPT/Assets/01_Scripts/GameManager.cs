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
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CheckGameState()
    {

    }










}
