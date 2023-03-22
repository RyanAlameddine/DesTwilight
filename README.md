# DesTwilight
Recreation of the popular board game Twilight Imperium 4th Edition so that I could keep playing with my friends during COVID.

Note that this project is just for fun, and while the source code is public, none of the game assets are in the repository and thus this should not be used as a replacement for buying the game.

![photo](https://github.com/RyanAlameddine/DesTwilight/raw/resources/READMEContent/photo.png)

### Includes all standard assets and mechanics including but not limited to:
- Planets
- Hazards
- Command Tokens
- Racial Sheets
- Technologies
- Agendas
- Political Cards
- Ships
- Ground Forces
- Space Docks
- PDS
- War Suns
- Wormholes
- Virus Tokens
- Commodities/Trade Goods

## Control Scheme
- First person
- Pivots around focus point

## Multiplayer
- TODO


## Feature Demos

At the start of the game, players are presented with all available faction sheets and home systems.

![photo](https://github.com/RyanAlameddine/DesTwilight/raw/resources/READMEContent/intro.gif)

Once they have selected their faction, they can load in all the corresponding faction-specific assets with the click of a button.

![photo](https://github.com/RyanAlameddine/DesTwilight/raw/resources/READMEContent/faction.gif)

Additionally, each player can select the color cube corresponding to their chosen color to load in all ships, units, technologies, and promissory notes.

![photo](https://github.com/RyanAlameddine/DesTwilight/raw/resources/READMEContent/red.gif)

Finally, when everyone has selected their faction and color, clicking the speaker token will load in all the cards and tokens required for the game.

![photo](https://github.com/RyanAlameddine/DesTwilight/raw/resources/READMEContent/speaker.gif)

### Quality of Life features

In addition to being able to pick up components, flip components, rotate components, lock components (so they cant accidentally be moved), and full camera mobility, I implemented a few more quality of life features for the fancier components.

Firstly, I implented a "deck" system that allows card objects to merge together into larger deck objects(proportionally sized based on the number of cards contained). As shown below, each deck supports removal by simply shift-dragging off the top, and addition by simply dropping a card onto the deck.

![photo](https://github.com/RyanAlameddine/DesTwilight/raw/resources/READMEContent/deck.gif)

Finally, I built the system tiles to snap to the hexagonal grid for ease of map building.

![photo](https://github.com/RyanAlameddine/DesTwilight/raw/resources/READMEContent/snapping.gif)
