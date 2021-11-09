# GroceryApp
Mobile app used to help make remembering grocery items even easier. No more pen &amp; paper!

## Project Requirements
The grocery app had a few requirements for each page within the app. The final app has implemented all requirements, and does not crash.
### Main Page 
The title "Grocery List" should appear on the main page.
Your name must appear in a label at the above the grocery list.
If there are no items in the list, your page should have a informational label with "Add some groceries."
If there are items in the list, show the grocery list.
Each list item shows the category name - grocery name.  For example:   Beverages - Skim Milk
On the second line, show the quantity.  Note that the quantity can be a real number  ( eg. 2.5 pounds of ground beef).
There is a plus "+" button in the title bar that adds a new grocery item to the list.
The + button takes you to a detail screen.
Groceries are listed in the main screen.  If the user taps a grocery, they are also taken to the detail screen but where they can edit the grocery.
### Details Page 
The detail screen has three input fields.  Grocery Item Name, quantity, and picker wheel with a category.
Grocery Item name is required.  Category and quantity is not required.  User input errors should be gracefully handled.
Note that the user can navigate to this screen by either adding a new grocery or editing an existing grocery.
There are always buttons on the bottom with Save and Cancel.   If a user is Editing, there is a delete button as well.
Save - Saves the data and persists it to a file in JSON format.  User returns back to the main screen.  List of groceries displayed reflect the changes.
Cancel -  User returns back to the main screen with no changes.
Delete - Item is deleted. User returns back to the main screen.  List of groceries displayed reflect the changes.  This button is only visible if the user is editing.
An empty quantity should stay empty.  It should not default to a 0.
Similarly, if not category is selected, do not default to the first category.  Your picker can just show the placeholder text.

## How Does it Work? - Behind the Scenes
### Data Handling
The real heart of the project lies within the handling of data. All data is processed inside a singleton, where CRUD operations are used to manage the data. The main page subscribes to the singleton to get notified of the creation, update, and deletion of the data.
#### Read Data
The main page of the app is where data is read and displayed to the user. This is done through binding data pieces to a list view.

![ScreenShot](/screenshots/listEmpty.png)
#### Create/Update Data
The details page is where data is created and updated. Users can either click the + sign in the Toolbar to add a new item to the grocery list. This action will bring the details page to the top of the page stack and allow the user to enter common grocery items. No field on this page is required except for the name of the actual item. Further, the user can just select something from the list view which will bring up the details page populated with appropriate data. From here all fields can be removed except for the name field.
### Adding an Item to the List
![ScreenShot](/screenshots/additem.png)![ScreenShot](/screenshots/error.png) 
![ScreenShot](/screenshots/listFull.png)
#### Delete Data
Lastly, the user can delete items from the grocery list. When an item is selected from the list, a delete button appears on the details page. 
### Editing Item From List
![ScreenShot](/screenshots/edititem.png)
### Finalized Grocery List
One item has been edited, and another deleted. (left -> right, final & beginning lists)

![ScreenShot](/screenshots/finalList.png)![ScreenShot](/screenshots/listFull.png)


## Tools/Libraries
* Newtonsoft
* LINQ
* Xamarin/C#
* Visual Studio

## Installation 
### Prerequisites
For this project, it will be assumed that Visual Studio is installed and has the Xamarin module installed as well. Also, due to the size the project and GitHub limitations the solution does not have an IOS/Android project with the solution. This can be easily fixed by adding the preferred mobile project to the solution.
### Run Project
1. Extract the .zip to any directory of your choice.
2. Open GroceryApp/GroceryApp.sln file in Visual Studio
3. Go to top toolbar click Build --> Build GroceryApp to build the project
4. Make sure to have either IOS/Android emulator installed and set up correctly inside of the solution
5. Run the project

