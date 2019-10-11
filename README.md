# TestProjectArkanoid
This is one of my test game project. I create simple version of original Arkanoid game. 

![](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/ExampleGamePlay.gif "Example")

Level builder settings:

![](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/Lvl%20Builder.png "Lvl-Builder")

He make level from bricks with random sprites (colors).

If player win or lose -  in result popup of the game end text will be changed.
![End Game Popup](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/GameWinPopup.gif "End Game Popup")

## Patterns and Tools
I'm used MVC for GUI and to controle the state of the game.

Animation or popup i'm make with [DOTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676), example code:
```
//Popup menu
    transform.DOScale(Vector3.one, 0.5f).SetEase(_animationScaleIn);
    transform.DOLocalJump(Vector3.one, 2f, 1, 0.5f, true);

//Vignette
    DOTween.ToAlpha(() => Vignette.color, x => Vignette.color = x, 0.5f, 0.35f)

```
