```                                                                                                        
##     ## ########   ######       ####       ########   #######  ##      ## ##    ##  ###### 
##     ## ##     ## ##    ##     ##  ##      ##     ## ##     ## ##  ##  ## ###   ## ##    ##
##     ## ##     ## ##            ####       ##     ## ##     ## ##  ##  ## ####  ## ##      
##     ## ########   ######      ####        ##     ## ##     ## ##  ##  ## ## ## ##  ###### 
##     ## ##              ##    ##  ## ##    ##     ## ##     ## ##  ##  ## ##  ####       ##
##     ## ##        ##    ##    ##   ##      ##     ## ##     ## ##  ##  ## ##   ### ##    ##
 #######  ##         ######      ####  ##    ########   #######   ###  ###  ##    ##  ###### 
```

## Overview

_Ups & Downs_ is a reimagining of the Milton Bradley board game _The Game of Life: Twists & Turns_.

## Architecture

_Ups & Downs_ was originally being built using **Blazor** such that it could be run on a Raspberry Pi 5. While that did work, it was also a pain to work _with_. That said, the project is being built using **WPF** now.

## Gameplay Mechanics & Changes

_The Game of Life: Twists & Turns_ has some pretty cool aspects to it, but it also has some shortcomings that I think can be improved on:

### Streamlined turn-taking -> Automation & UX Optimization

In _Twists & Turns_, whenever it's a player's turn, they have to:

1. Grab the game unit
2. Insert their card, wait briefly for it read the card detent and be ready to accept input
3. Press 'Spin'
4. Move their car-pawn on the board
5. Press the dial buttons as needed based on where they land on the board
6. Input numeric/selector values via the +/- buttons and confirm via the 'Enter' button

Step 6 alone, in the simplest case such as gaining/losing money, it can involve **no fewer than 6 button presses**:

1. '$' button
2. Numeric value via dial buttons, with a minimum of +/- 100 increments, so three digits
3. +/- button
4. 'Enter' button

All the while, the other players don't have much to do. Therefore, my intent is to streamline this part of the game heavily:

1. Anything that doesn't add to gameplay and can be automated should be handled by the game software.
   * While it's nice that _Twists & Turns_ has physical cards to read, they add even more downtime during a player's turn. They rarely do more than say, "This thing happened, add/remove $X and/or life points". This game mechanic will be handled by the game unit (see below).
   * Effects of landing on a given space will be handled by selecting the corresponding space on the game unit, and from there the game unit will quickly walk through the results while taking into account favors and demerits (see below).
2. Whenever a user needs to interact with the game itself via the touchscreen or otherwise, the interaction should require as few steps as possible.

### More dynamic situations -> Randomized Events & 'LIFE' Cards

In _Twists & Turns_, there's a significant gap during gameplay where you aren't really doing anything. There isn't any strategy to speak of really outside of momentary decisions during your turn. Since this is a simple game, that's not a terrible thing, but I'd like to add a couple of mechanics that a player can at least be thinking about outside of their turn. Besides the turns that player's take, there will also be randomized events that occur during and between turns. 

What used to be a player drawing and reading a LIFE card will now be handled entirely by the game unit, saving time for all players.

### More agency/control for each player -> Favors & Demerits

Randomized events that pertain to a particular player will have a modifier mechanic that the player can control to hopefully improve the outcome. This is where favors and demerits come into play. If a player has favors on hand to cash in, they can improve the outcome of an event if they choose to. If they have accumulated any demerits, then they _must_ use them in the event, which will worsen the outcome.

## Hardware

The current intended hardware spec is:

```
GMKtec Mini PC
1024x600 7" Touchscreen
Mini Receipt Printer
```

## References

![image](https://github.com/user-attachments/assets/163c3cba-c944-4abc-a8bb-a59d6635b812)
