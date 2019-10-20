using System;
using Arkanoid;
using UnityEngine;

public class FitToSizeScreen : MonoBehaviour
{
    [SerializeField] private int WidthScreenDefault = 1920, HeightScreenDefault = 1080;

    private GameModel _gameModel;

    private void Awake()
    {
        if (Screen.height > WidthScreenDefault & Screen.width > HeightScreenDefault) throw new Exception("You must set default screen size");
        _gameModel = GameModel.Instance();
        _gameModel.SetScreenSizeDefault(WidthScreenDefault, HeightScreenDefault);
    }
}
