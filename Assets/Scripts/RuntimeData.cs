using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Runtime Data")]
public class RuntimeData : ScriptableObject {
    
    public GameplayStates current_gameplay_state;

}