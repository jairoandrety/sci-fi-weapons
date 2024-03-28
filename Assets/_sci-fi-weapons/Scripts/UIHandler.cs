using System;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public Action OnChangeScene;

    public void SelectScene()
    {
        OnChangeScene?.Invoke();
    }
}
