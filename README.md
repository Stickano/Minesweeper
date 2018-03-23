# Minesweeper
CLI Minesweeper in C#

This is one of two projects I have to create throughout this semester in Programming for Control Applications, University of Pardubice (Czech). The next project will be a GUI Pacman-like game. This though, is a remake of the classic Minesweeper game - Made as a Console Application. 

### The Game and its Logic
When you run the game you will be asked about the Board size. You can pick either a small board with 100 tiles and 10 bombs, or a large board with 400 tiles and 80 bombs. The board will then be generated with randomly placed bombs and surrounding tiles will be updated with a nearby bomb amount value.

A player can move around with the *Arrow* keys and turn tiles with *Space*. If a player suspects a tile has a bomb, the player can mark that tile with *M*. Once a player turns a tile, and it's not a bomb, the surrounding tiles with zero bombs and their subsequent tile with a surrounding bomb will also turned. This logic was added later on and the issues I had because of this feature and some of the legacy code.. Never again. 

The turned tiles will be colored according to how many bombs are detected nearby. The game uses 3 custom models; Tile, Board and Controls. A Board object will generate a board, with Tile objects, and keep track of bomb placements, turned and marked tiles and so forth. The Controls class is for the user-controls/navigation. 

<p align="center"><img src="https://github.com/Stickano/Minesweeper/blob/master/preview.png"/></p>

##### Pro Tip!
The logic makes it so that you never get a bomb in the outer most tiles of the board - No help clearing is available for outer most tiles either. It's a good way to get started with the game though. Just clear the outer most tiles and move towards the center. 
