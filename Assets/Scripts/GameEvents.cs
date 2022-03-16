using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEvents {

    public delegate void PuzzleInitiated(object sender);
    public delegate void Puzzle();

    public static event PuzzleInitiated PuzzleStart;
    public static event Puzzle PuzzleFinish;

    public static void on_puzzle_Start(object sender) {
        PuzzleStart(sender);
    }

    public static void on_puzzle_End() {
        PuzzleFinish();
    }

}