using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "uniform", "arrest" };

    #region Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;
#endregion

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        password = "";
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // Can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please input a valid response Mr. Bond!");
        }
        else if (input == "69")
        {
            Terminal.WriteLine("A real response you dirty man");
        }
        else if (input == "420")
        {
            Terminal.WriteLine("Blaze in a real response kthx");
        }
        else
        {
            Terminal.WriteLine("Please input a valid response");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Please input your password:");
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Incorrect password. Try again: ");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book!");
                Terminal.WriteLine(@"
    _______
   /     //
  /     //
 /____ //
(_____(/
"               );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '
"               );
                break;
        }
    }
}
