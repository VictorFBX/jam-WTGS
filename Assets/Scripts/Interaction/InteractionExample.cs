using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractionExample : MonoBehaviour
{
    [SerializeField] private Color targetColor;
    private Color default_color;
    private GameObject cube_ref;
    
    public RuntimeData data;

    void Awake() {
        GameEvents.PuzzleStart += on_puzzle_start;
        GameEvents.PuzzleFinish += on_puzzle_finish;

        cube_ref = transform.Find("Cube").gameObject;
        default_color = cube_ref.GetComponent<Renderer>().material.color;
    }

    void OnDisable() {
        GameEvents.PuzzleStart -= on_puzzle_start;
        GameEvents.PuzzleFinish -= on_puzzle_finish;   
    }

    void OnTriggerExit(Collider collision) {
        cube_ref.GetComponent<Renderer>().material.color = default_color;
    }

    //callback signals events
    void on_puzzle_start(object args)
    {
        if (args.Equals(gameObject))
            cube_ref.GetComponent<Renderer>().material.color = targetColor;
    }
    void on_puzzle_finish() {
        Destroy(this.gameObject);
    }
}
