# 1) Introduction to Unity Scripting - Sheep Game

This is the first game in the portfollio for ID623001 Intro to Algorithmic problem solving. In this game you have to rescue sheep by shooting hay bales at them before they run off the edge world. The rate at which the sheep spawn and their run speed increase over time to increase the difficulty. The game ends when the player fails to rescue 3 sheep, causing a game over. The Highscore is saved for multiple playthroughs until the game is closed.

## Advanced Assessment Tasks
For the Advanced assessment task i had to make the sheep speed and spawn rate increase over time and create a highscore that persisted between scenes. To create the highscore I had a highscore manager in each scene which had a static integer called highscore. Whenever the game was running it checked the current score against the highscore and updated the highscore accordingly. Since static variables update with the class and not each object it kept the changes between each scene. 

## References
https://stackoverflow.com/questions/69321984/increasing-variable-gradually-in-unity-the-variable-keeps-reverting - Used as a guide for increasing sheep speed and decreasing spawn time
