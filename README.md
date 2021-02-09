# Tragedy Looper - Screenshare

This is a simple Unity game designed to help play the board game [Tragedy Looper](https://boardgamegeek.com/boardgame/148319/tragedy-looper) with others via an external chat and screen sharing program.  As such, it is intended to be run by one player (the Mastermind) and input to/from the other 1-3 players should be given via voice or text chat.  

The game assumes that the players are familiar with the basic premise and/or have access to the [player's](https://images.zmangames.com/filer_public/bc/e8/bce8e73f-d200-4a9f-be90-b3c59b8bb330/zm7470_tragedy_looper_rules.pdf) and [mastermind's](https://tesera.ru/images/items/456060/Tragedy_Looper_Masterbook.pdf) handbooks.  Basic card information is encoded into the display, but scenarios, plot and sub-plot rules, and character abilities must all be referenced externally.

## Running
This is written for Unity 2019.4 and can be run or compiled from within the Unity editor.  Compatibility has not been checked with other versions, so you may attempt to use them at your own discretion.  No external packages are required.  A compiled Windows executable may be uploaded at a later date: check the `tages/releases` section to see.  

## Playing Instructions
The interface is a simple drag and drop to move cards and tokens around on the game board.  The background displays the main game board with hospital, shrine, city, and school quadrants.  A secondary incident board is on the right to mark the current day, loop, and any incident or other markers.  

Right clicking on any space not occupied by a card/token will bring up the object creation menu.  From here, you may generate any character card, mastermind card back, or intrigue token.  Once a card/token has been created, it can be dragged into position.  

Right clicking on a character card will bring up an options menu, allowing you to add/remove goodwill or paranoia, mark the character as dead, or remove the card.  Right clicking on a token or mastermind card will immediately remove that object.  Mastermind cards are dispalyed only as card backs.  There are used to indicate for the players where these cards have been positioned during the mastermind's turn, but they cannot be flipped.  The mastermind must indicate which cards were used during the resolution phase, and the players must do the same with their own plays (no method to mark player cards is generally needed).

The incident board runs by left clicking in any of the numbered spaces to change the marker positions.  The day, loop, and extra gauge spaces are limited to a single markers, which will jump to the most recently clicked position.  The incidents column can have a marker on as many days as necessary; clicking on an empty space will create a marker, and clicking again will delete it.

There is currently no menu option to exit the game.  This will be added in the future, but currently the only method of quitting is alt-F4 (or the appropriate replacement for your platform).

## Art
The game assets are a mixture of programmer art and modified public domain pieces (see [Attributions.txt](/Attributions.txt) for artwork sources and licenses).  If you have rights and access to official artwork, however, it is fairly straightforward to plug the respective files into the prefabs for the board, tokens, and reference cards.  No character card art is supplied: they appear blank except for the name and goodwill/paranoia levels.  Optional art can be attached to the individual card data objects found in the Assets/CharacterCardData directory.
