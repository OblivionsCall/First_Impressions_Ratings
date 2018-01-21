First Impressions Ratings
Version 0.1
Author: Chris "OblivionsCall" Hand
This project is licensed under the terms of the MIT License

ABOUT
This project came about when I was thinking about searching algorithms and I figured out a shell to build around that. Simply put, this application is one where you feed it a list of games and it gives you the ability to rate games from the list. 

The main feature is the "Random Game" feature where the idea is it gives you a random game from the list that you haven't played yet and you have to go play it for an hour and then can give a first impression rating. 

Currently that is the only feature in the program but I am working to implement a search and a top 10 feature so you can see what you most enjoyed. 

USE
The program creates a "Lists" local directory and an Example.txt file within if one does not currently exist (TODO - make this optional in a config file).

Navigation is done by entering the number of the desired option (or entering the prompted text) and pressing "Enter".

LIST FILES
List files are simple. 

If the first character on a line is '#', it is considered a comment and ignored.

When creating a list, all that is necessary is that each game name be on its own line. The program adds the header and all values. Any user added comments are currently not preserved unfortunately.

As these are text files edits to the ratings can be done in the files themselves, not the application as the point of this program is for the ratings to be "first impressions". If values are edited, averages are calculated upon list creation and not retained in the text file.