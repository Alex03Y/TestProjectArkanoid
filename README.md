# TestProjectArkanoid
This is one of my test game project. I create simple version of original Arkanoid game. 

![Example](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/ExampleGamePlayHighFps.gif)

Settings lvl-builder:

![Lvl-Builder](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/Lvl%20Builder.png)

Him make lvl of bricks with random sprites (colors).

If player win or lose -  in result popup of the game end text will be changed.
![End Game Popup](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/WinPopup.gif)


I'm used MVC for GUI and to monitor the state of the game.

Animation or popup i'm make with DOTween, example code:

  '//For popup menu
  'transform.DOScale(Vector3.one, 0.5f).SetEase(_animationScaleIn);
  transform.DOLocalJump(Vector3.one, 2f, 1, 0.5f, true);

  //For Vignette
  DOTween.ToAlpha(() => Vignette.color, x => Vignette.color = x, 0.5f, 0.35f)
