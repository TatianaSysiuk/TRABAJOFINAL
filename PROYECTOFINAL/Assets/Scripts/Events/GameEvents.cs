using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEvents {
    
    public static event Action<int> OnScore;

    public static void OnScoreCall(int score) { OnScore?.Invoke(score); }
}
