using UnityEngine;

public class Hacker : MonoBehaviour
{
    string menuHint = "Type menu to go back";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

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
        Terminal.WriteLine("Press 1 for the local Library");
        Terminal.WriteLine("Press 2 for the local Police Station");
        Terminal.WriteLine("Press 3 for NASA Command Station");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // Can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on web close the tab.");
            Application.Quit();
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
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

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Enter your password. Hint: " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
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
                Terminal.WriteLine(menuHint + " for a greater     challenge.");
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '
"               );
                Terminal.WriteLine(menuHint + " for a greater     challenge.");
                break;
            case 3:
                Terminal.WriteLine(
@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|");
                Terminal.WriteLine("Welcome to NASA's Internal System.");
                Terminal.WriteLine("Congratulations! You've hacked the     highest level of security.");
                Terminal.WriteLine(menuHint);
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
