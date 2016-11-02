# PermutateSudokuV4
Application to generate every possible sudoku puzzle

The classic Sudoku game involves a grid of 81 squares. 
The grid is divided into nine blocks, each containing nine squares.

The rules of the game are simple: 
each of the nine blocks has to contain all the numbers 1-9 within its squares. 
Each number can only appear once in a row, column or box.

The difficulty lies in that each vertical nine-square column, 
or horizontal nine-square line across, within the larger square, 
must also contain the numbers 1-9, without repetition or omission.

This is a duanting task, "the number of valid Sudoku solution grids for the standard 9×9 grid 
was calculated by Bertram Felgenhauer and Frazer Jarvis in 2005 to be 6,670,903,752,021,072,936,960 . 
This number is equal to 9! × 722 × 27 × 27,704,267,971, the last factor of which is prime.Aug 11, 2011 
 - Google: https://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=number%20of%20sudoku%20solutions
 
 I have been working on sudoku since 2010, This was the project that i used to learn programming. It started out with as a simple
 windows form to house the game itself, while developing the form however, I ran into a bit of a conundrum, how would I lock down values?
 I did some research and saw that there where actually formulas to do this, however, not all formulas where known and I am not a math wiz.
 I started to think that it would be cool to have a data base of every solution possible and to be able to provide data to the player
 using that database. I began blind into this process of generating every solution. teaching my algorithms to abide by the rules of sudoku
 and creating algorithms that would not need to check for duplicate solutions in my data set. Once i got an implimentation working I began
 doing math on how many itterations I would have to preform and how long it was taking to generate solutions. The numbers where unreal.
 It would take over a life time of non-stop executing to generate every solution under the current technology and algorithm. Also if every
 solution could be stored in 1 byte of data it would take 7 of IBM's, at the time, top of the line peta-drives to store all solutions of a 
 single given first row. After realizing the size of the issue, my focus has shifted, it not neccessarily about having a database of every
 solution possible anymore, instead I just want to come up with the best algorithm to eventually generate these solutions in a timely 
 maner. I can focus on how to reduce the data storage size at a later time, all though some effort is required in this as it can have an
 effect on the "speed" of an algorithm.
 
When I first started generating solutions I was generating numeric solutions, I quickly realized however that if you replaced the numbers 
1,2,3,4,5,6,7,8,9 with a,b,c,d,e,f,g,h,i and applied substitution to those values, you could complete 362,880 different numeric solutions
off of each one of these patterns. 
