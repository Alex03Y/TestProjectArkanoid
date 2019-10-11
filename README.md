# TestProjectArkanoid
This is one of my test game project. I create simple version of original Arkanoid game. 

![](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/ExampleGamePlayHighFps.gif "Example")

Settings lvl-builder:

![](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/Lvl%20Builder.png "Lvl-Builder")

Him make lvl of bricks with random sprites (colors).

If player win or lose -  in result popup of the game end text will be changed.
![End Game Popup](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/WinPopup.gif "End Game Popup")


I'm used MVC for GUI and to monitor the state of the game. 
[](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/MVC%20and%20ObserverPattern.png "MVC and ObserverPattern")

Animation or popup i'm make with DOTween, example code:
```
//Popup menu
    transform.DOScale(Vector3.one, 0.5f).SetEase(_animationScaleIn);
    transform.DOLocalJump(Vector3.one, 2f, 1, 0.5f, true);

//Vignette
    DOTween.ToAlpha(() => Vignette.color, x => Vignette.color = x, 0.5f, 0.35f)

```
