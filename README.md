# Tower of Hanoi

This is an implementation of the classic game Tower of Hanoi in a 3D environment.
Link to the [game demo on itch](https://davidcode.itch.io/tower-of-hanoi)

## Breaking down the game:
Rules and Setup:
- The disk can be placed in any of the rods.
- The disk is in descending order, being the largest disk at the bottom of the stack.
- Only one disk can be moved at a time. Releasing a disk in the void, place it again in its original position.

User interactions:
- Select a disk that is on top of the rod (Stack)
- Place it on a rod that is either empty or has its last disk (peek()) greater than the selected disk.
- Return the disk to its original position if the user releases it.

Win state:
- When all the discs are placed in descending order in a rod (Stack) that was empty at the beginning of the game. (safe the empty rods)

## Systems:
- User Input event handlers  - Implemented
- Score count, number of moves - Implemented
- Reset option: The original position of the bricks and counter is set to zero. - Not Implemented.
- Animation of moving the bricks: StateMachine. - Not Implemented.

## DataStructures
- The rods and disk have a "Stack" behavior. So can have Three Stacks, one for each rod.
- Integers can represent the elements.
- We need to count every time an element gets pushed on Stack.

# DevLog
1. No major use of AI, only double checking with ChatGPT the C# syntaxsis.
2. What considerations would you make if this game were to be displayed in a public setting? A: Regarding the size of the display and orientation, I realize that depending on whether the display is placed vertically, a top view would not have worked. 
3. What considerations would you make if this game was implemented on a multitouch screen? A: Considering 