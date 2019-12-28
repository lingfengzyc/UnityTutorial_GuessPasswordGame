
using UnityEngine;



public class Hacker : MonoBehaviour {

    //Game configuration data
    const string menuHint = "Type 'menu'to go back";
    string[] level1Passwords = { "books", "aisle", "shelf","password","font","borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "Mercury", "Venus", "Earth", "Mars", "Jupiter" };


    //Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;
    

 

    // Use this for initialization
    void Start () {
        showMainMenu();
        

    }//
	

    void showMainMenu(){

        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the NASA");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            showMainMenu();
        }
        else if(input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            runMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
    }

    

    void runMainMenu(string input)
    {
        bool isVaildLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isVaildLevelNumber)
        {
            level = int.Parse(input);//change string to int
            AskForPassword();
        }
        
        else
        {
            Terminal.WriteLine("You need to choose a vaile level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);


    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;
            default:
                Debug.LogError("Invaild level number");
                break;
        }
    }

    void checkPassword(string input)
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
        currentScreen=Screen.Win;
        Terminal.ClearScreen();
        showLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void showLevelReward()
    {
        switch (level)
        {
            case 1:
             Terminal.WriteLine("Have a book...");
             Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/

");
             break;
           case 2:
                Terminal.WriteLine("Have a police car");
                Terminal.WriteLine("Play again for a greater challenge.");
                Terminal.WriteLine(@"
    _
  _|_|__
 /|_||_\`.__
(   _    _ _\
=`-(_)--(_)-' 
"
          );
                
                break;

            case 3:
                Terminal.WriteLine("Have a moon");
                Terminal.WriteLine(@"

 ,-,
/.(
\ {
 `-`
"
                  );
                
                break;
            default:
                Debug.LogError("Invaild level number");
                break;
        }
    }
}
