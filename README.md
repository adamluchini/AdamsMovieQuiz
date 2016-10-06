# Adam's Movie Quiz
### 10/06/2016

# Epicodus Final Independent Project by Adam Luchini

## Description

Adam's Movie Quiz is a C# application containing a test on 10 movie titles. When a user clicks one of the 10 buttons, they are given a key clue one at a time to see if they can correctly guess the title. First, the year of release, genre, and director is given. Second, the top billed actors. And lastly, a brief plot. At any point, the user can guess and their answer is immediately determined whether it's correct or not. Adam's Movie Quiz retrieves all movie data by making API GET requests to [IMDb](http://www.imdb.com/). This was made possible by utilizing the unofficial and unaffiliated web API service [OMDb](http://www.omdbapi.com/), a project by [Brian Fritz](mailto:bfritz@fadingsignal.com/).

## Specifications
The capabilities of Adam's Movie Quiz are as follows:
* Users are able to create a user name and password, which is stored in a SQL database.
  * Example: After clicking register, phillip@gmail.com is entered as an email and valid password.

* Users can log in after registering.
  * Example: After clicking log in, "Welcome, phillip@gmail.com" is displayed on the index page.

* Users can select any of the 10 listed movies.
  * Example: A user already tried Movie 1 and 2, so they want to try 3. Rather than stepping back through and playing 1 and 2 again, they can start off at 3 directly.

* Movie clues are given one at a time.
  * Example: Clue 1 displays "Released in 1978, this Horror film was directed by John Carpenter" and also the button for Clue 2 if the user wants to see.

* A user can guess the movie at any time.
  * Example: A user knows the answer after Clue 2, "Starring Donald Pleasence, Jamie Lee Curtis, Tony Moran" and wants to guess. They type "Halloween" into the text box and hit submit.

* If the answer is correct, it is revealed as such.
  * Example: After typing in "Halloween", a "That is correct!" page is displayed, along with the film's theatrical poster.

  * If the answer is incorrect, it is revealed as such and the correct answer is given.
    * Example: After typing in "Nightmare on Elm Street", a "Sorry, the answer was Halloween" page is displayed, along with Halloween's theatrical poster.

* Guesses do not have to case sensitive.
  * Example: Clues prompt the user to assume the movie is "Back to the Future", so they type in "back to the future". All answer are converted to lowercase so the answer will be judged as correct.

## Setup/Installation Requirements

You will need the following properly installed on your computer.

* [Microsoft Visual Studio 2015](https://www.visualstudio.com/downloads/)
* [Windows PowerShell](http://go.microsoft.com/fwlink/?LinkId=293881)
* [Microsoft SQL Server Management Studio](https://msdn.microsoft.com/en-us/library/mt238290.aspx)
*

* Clone this repository through GitHub by clicking the "Open in Visual Studio" prompt and follow the commands.
* After successfully cloning, download the RestSharp.NetCore dependency from the NuGet Package Manager.
* In PowerShell, update the registration database by navigating to the solution directory and enter "dotnet ef database update"
* Click the run option in Visual Studio to run the applications
* Register an email and password.
* Enjoy and good luck!

### Technologies Used

C#, ASP.NET, Entity Framework, Bootstrap, HTML 5, CSS, AJAX, RestSharp.

### Future Plans

Creating a single movie class and pulling a variable from the home page based on a button click will lighten this bad boy up A LOT.

## Contact

* [Adam Luchini](https://github.com/adamluchini)


## License
This software is licensed under the MIT license

Copyright (c) 2016 All Rights Reserved.
