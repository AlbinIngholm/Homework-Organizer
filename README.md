#Homework-Organizer

###A simple console application written in C# to help organize and keep track of your homework.
Features

    Add new homework: Easily add new assignments with a title and description.
    Mark homework as complete: Change the status of your homework when it's done.
    View all homework: List all current assignments with their completion status.
    Simple navigation: Use a numbered menu to select actions in the program.

##Usage

Once the application starts, you will be presented with a menu:

    Add new homework
    Mark homework as complete
    View all homework
    Exit the application

Simply input the corresponding number to perform the desired action.


##How it works

    Adding homework: You will be prompted to input the title and description.
    Marking as complete: Choose a homework item to toggle its completion status.
    Viewing all homework: Displays each homework item with its title, description, and status ("Fullført" or "Ikke fullført").

##Code Structure

    Lekse: A class representing a homework item with properties like title, description, and completion status.
    Functions include:
        NyLekse(): Adds a new homework item.
        SnuStatus(): Toggles the completion status of a homework item.
        SkrivUtLekser(): Displays all homework items with their details.

##Requirements

    .NET 6 or higher installed.

##How to run

    Clone the repository:


git clone https://github.com/AlbinIngholm/Homework-Organizer.git

Navigate to the project directory:

cd homework-organizer

Build and run the application using your preferred IDE or .NET CLI.
