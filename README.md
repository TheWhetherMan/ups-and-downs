# Ups & Downs

## Overview
_Ups & Downs_ is a reimagining of the Milton Bradley board game _The Game of Life: Twists & Turns_. 
The goal is to create a similar overall game, but with streamlined turn-taking, more agency/control for each player, and more dynamic situations both from one turn to the next, and between subsequent game sessions.

## Architecture
_Ups & Downs_ is partly experimental in that it is being built on **Blazor**, but ideally it should be playable on anything that can run a reasonable browser engine. 

## Hardware
The current intended hardware spec is:
```
Raspberry Pi 5 (2GB)
1024x600 Touchscreen
Adafruit Mini Receipt Printer
```

## Rough Gameplay Mechanics Comparison
```
╔════════════════════════════╗                                         
║    LIFE: TWISTS & TURNS    ║░░                                       
║             ─              ║░░                                       
║       GAME MECHANICS       ║░░                                       
╚════════════════════════════╝░░                                       
  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                                       
                                                                       
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃                                                                     ┃
┃                    BASIC TURN FLOW - ALL PLAYERS                    ┃
┃                                                                     ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
┌───────────────┐ ┌───────────────┐ ┌───────────────┐ ┌───────────────┐
│               │ │               │ │               │ │               │
│  PLAYER ONE   │ │  PLAYER TWO   │ │ PLAYER THREE  │ │  PLAYER FOUR  │
│               │ │               │ │               │ │               │
└───────┬───────┘ └───────┬───────┘ └───────┬───────┘ └───────┬───────┘
        ○                 ○         ┌───────▼───────┐         ○        
                                    │  DO ALL THE   │                  
                                    │ THINGS ON THE │                  
                                    │   "LIFEPOD"   │                  
                                    └───────────────┘                  
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃                                                                     ┃
┃                    BASIC TURN FLOW - PER PLAYER                     ┃
┃                                                                     ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
┌───────────────┐ ┌───────────────┐ ┌───────────────┐ ┌───────────────┐
│               │ │               │ │               │ │               │
│  INSERT CARD  ├─▶     SPIN      ├─▶ MOVE ON BOARD ├─▶ ACT ON SPACE  │
│               │ │               │ │               │ │               │
└───────▲───────┘ └───────────────┘ └───────────────┘ └───────┬───────┘
        │         ┌─────────────────────────────────┐ ┌───────▼───────┐
        │         │                                 │ │               │
        └─────────┤    NEXT PLAYER GETS LIFEPOD     ◀─┤  REMOVE CARD  │
                  │                                 │ │               │
                  └─────────────────────────────────┘ └───────────────┘
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃ISSUES WITH BASE GAME MECHANICS:                                     ┃
┃ - PLAYERS NOT ACTIVELY TAKING THEIR TURN HAVE NOTHING TO DO         ┃
┃ - LITTLE-TO-NO STRATEGY IS POSSIBLE:                                ┃
┃   - OUTCOMES GENERALLY ARE COMPLETELY RANDOM                        ┃
┃   - LIFE POINT ACCRUAL IS BASICALLY DETERMINED BY "SPEED":          ┃
┃     - HIGHER ROLLS => HIT MORE PROMOTIONS, LIFE EVENTS, ETC.        ┃
┃ - CERTAIN LIFE CARDS CAN WILDLY SWING THE GAME                      ┃
┃ - PLAYERS HAVE LITTLE AGENCY OVER THE GAMEPLAY WITH EXCEPTION OF:   ┃
┃   - CAREER PATH BASED ON DEALT CARDS AT GAME START                  ┃
┃   - DIRECTION TO GO AT PATH FORKS ON THE BOARD                      ┃
┃   - WHETHER OR NOT TO BUY/SELL ASSETS WHEN APPLICABLE               ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
╔════════════════════════════╗                                         
║        UPS & DOWNS         ║░░                                       
║             ─              ║░░                                       
║       GAME MECHANICS       ║░░                                       
╚════════════════════════════╝░░                                       
  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                                       
                                                                       
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃                                                                     ┃
┃                    BASIC TURN FLOW - ALL PLAYERS                    ┃
┃                                                                     ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
┌───────────────┐ ┌───────────────┐ ┌───────────────┐ ┌───────────────┐
│               │ │               │ │               │ │               │
│  PLAYER ONE   │ │  PLAYER TWO   │ │ PLAYER THREE  │ │  PLAYER FOUR  │
│               │ │               │ │               │ │               │
└───────┬───────┘ └───────┬───────┘ └───────┬───────┘ └───────┬───────┘
┌───────▼─────────────────▼─────────────────▼─────────────────▼───────┐
│                             TAKE TURNS:                             │
│    ROLL DICE, ACT ON SPACE, MARK SPACE LANDED ON VIA TOUCHSCREEN    │
└──────────────────────────────────┬──────────────────────────────────┘
┌──────────────────────────────────▼──────────────────────────────────┐
│              UPS & DOWNS APP ADVANCES GAME BY ONE YEAR              │
│             PLAYERS ARE INFORMED OF CHANGING CONDITIONS             │
└─────────────────────────────────────────────────────────────────────┘
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃                                                                     ┃
┃                    BASIC TURN FLOW - PER PLAYER                     ┃
┃                                                                     ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
┌───────────────┐ ┌───────────────┐ ┌───────────────┐ ┌───────────────┐
│               │ │               │ │               │ │               │
│   ROLL DICE   ├─▶ MOVE ON BOARD ├─▶ ACT ON SPACE  ├─▶  MARK SPACE   │
│               │ │               │ │               │ │               │
└───────▲───────┘ └───────────────┘ └───────────────┘ └───────┬───────┘
        └─────────────────────────────────────────────────────┘                                      
```
