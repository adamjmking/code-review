using UnityEngine;

/// <summary>
/// This script executes at runtime automatically. Instantiates a Systems prefab located in
/// the "Resources" folder before any scene is loaded and calls DontDestroyOnLoad on that
/// instance. This prefab contains child objects with our singleton systems/managers on it.
/// </summary>

public class Bootstrapper : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute() => Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("Systems")));
}