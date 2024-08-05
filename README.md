# Tower of Hanoi

This is an implementation of the classic game Tower of Hanoi in a 3D environment.

# Game Loop
- Strat Game
- Game play
- Game ends


# Breacking down the game:
Rules and Setup:
- The disk ccan be place in any of the rods.
- The disk are in descending order, bein the largest disk on the bottom of the Stack.
- Only one disk can be move at the time. Releasing a disk in the void place it again in it original position.

User interactions:
- Select a disk that that on top of the rod (stack)
- Place it on a rod that is either empty or that it last disk (peek()) is greater than the selected disk.
- Return the disk to the original position in case the user release it.

Win state:
- When all the disck are place, in descending order in a rod (stack) that was empty at the beginign of the game. (safe the empty rods)

# Systems:
- User Input event handlers
- Score count, numer of moves
- Reset option: original position of the bricks and counter to zero
- Animation of moving the bricks: StateMachine.

# DataStructures
- The rods and disk have a "Stack" behaviour. So can have Three Stacks, one for each rod.
- The elements can be represented by integers.
- We need to count every time an element gets pushed on stack.