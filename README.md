# TestProjectArkanoid
This is one of my test game project. I create simple version of original Arkanoid game. 
Made by Unity v2019.2.5f1.

![](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/Game%20Play.gif "Example") 

Border collider of the screen scaled to screen size and size image of canvas border. [Auto-resize border collider](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/AutoResizeBorderCollider.gif "Exemple changing resolution"). 
You must 
[specify](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Assets/Arkanoid/Scripts/FitToSizeScreen.cs) 
the screen resolution at which you created the scene and [assign](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Assets/Arkanoid/Scripts/Controllers/BorderController.cs) image border link.

Level builder is pretty simple, have a only one prefab, width and height counter with spacing options and pick random sprite for each line of blocks.

Settings:

![](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/Lvl%20Builder.png "Lvl-Builder")

Menu Popup.

Popup, text, substrate and button can be configured separately. Choose the desired location of the button. The remaining elements are tied to it.

![](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/Menu%20Popup.png "Menu popup")


### Patterns and Tools
All game logic and GUI logic assembled around MVC pattern.

If player win or lose -  in result popup of the game end text will be changed.
![](https://github.com/Alex03Y/TestProjectArkanoid/blob/master/Pictures/GameWin.gif "Win Game Popup")

Animation created by using [DOTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676) plugin.:

