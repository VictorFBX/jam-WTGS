using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private Color targetColor;
    [SerializeField] RuntimeData data;

    [SerializeField] PuzzleResource puzzle_res;
    private Color default_color;
    private GameObject cube_ref;

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


    private void startPuzzle() {
        var ui = gameObject.transform.Find("UI").gameObject;
        ui.GetComponent<Canvas>().enabled = true;

        GameObject image = ui.transform.Find("Texture").gameObject;
        image.GetComponent<RawImage>().color = new Color(1f,1f,1f,1f);
        image.GetComponent<RawImage>().texture = puzzle_res.backgroundImage;
    }

    //callback signals events
    void on_puzzle_start(object args)
    {
        if (args.Equals(this.gameObject))
            data.current_gameplay_state = GameplayStates.InPuzzle;
            cube_ref.GetComponent<Renderer>().material.color = targetColor;
            Cursor.lockState = CursorLockMode.None;
            startPuzzle();
    }

    
    void on_puzzle_finish() {
        Destroy(this.gameObject);
    }
}
