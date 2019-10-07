using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public enum MenuScreens { MainMenu, Credits }
    public enum Direction { Up, Down }

    [Header("Andet")]
    public TextMeshProUGUI[] Valgmuligheder;
    // Hvad kommer før en option
    public string OptionPrepend;

    // Options: Hvilke 'knapper' der er på de forskellige skærme.
    // Selected: Hvad der står på diverse 'knapper' når de er valgt.

    [Header("Main Menu")]
    public string[] OptionsMainMenu;
    public string[] SelectedMainMenu;

    [Header("Credits Menu")]
    public string[] OptionsCredits;
    public string[] SelectedCredits;
    
    private MenuScreens currentMenu = MenuScreens.MainMenu;
    private int currentIndex = 0;
    private int maxIndex;
    private string[] currentOptions;
    private string[] currentSelected;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        SwitchMenu(MenuScreens.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.Play(); ;
            SelectRelative(Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.Play(); ;
            SelectRelative(Direction.Down);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            print("Button activated");
            ButtonActivated(currentIndex);
        }
    }
    
    private void SelectRelative(Direction direction)
    {
        if (direction == Direction.Down)
        {
            currentIndex += 1;
        }
        else if (direction == Direction.Up)
        {
            currentIndex -= 1;
        }

        if (currentIndex < 0)
        {
            currentIndex = maxIndex;
        }
        else if (currentIndex > maxIndex)
        {
            currentIndex = 0;
        }

        SelectMenu(currentIndex);
    }

    private void SelectMenu(int index)
    {

        if (currentSelected.Length > index && currentSelected[index] != string.Empty)
        {
            for (int i = 0; i < currentOptions.Length; i++)
            {
                if (i == index)
                {
                    Valgmuligheder[i].text = OptionPrepend + currentSelected[i];
                    continue;
                }

                Valgmuligheder[i].text = OptionPrepend + currentOptions[i];
            }
        }
        //SelectNewOption(currentIndex);
    }

    private void RemoveSelection(int index)
    {
        Valgmuligheder[index].text = OptionPrepend + currentOptions[index];
    }

    // Switch between level selection-, creditsmenu and so on.
    private void SwitchMenu(MenuScreens menu)
    {
        switch (menu)
        {
            case MenuScreens.MainMenu:
                maxIndex = 2;
                currentOptions = OptionsMainMenu;
                currentSelected = SelectedMainMenu;
                break;
            case MenuScreens.Credits:
                maxIndex = 1;
                currentOptions = OptionsCredits;
                currentSelected = SelectedCredits;
                break;
            default: // Enumeratoren er ikke traditionel, returner for at forhindre en ulykke.
                return;
        }

        currentIndex = 0;

        for (int i = 0; i < Valgmuligheder.Length; i++)
        {
            if (currentOptions.Length > i)
            {
                Valgmuligheder[i].text = OptionPrepend + currentOptions[i];
                continue;
            }

            Valgmuligheder[i].text = "";
        }

        SelectMenu(currentIndex);
    }

    // When enter is pressed basically.
    public void ButtonActivated(int buttonIndex)
    {
        switch (currentMenu)
        {
            case MenuScreens.MainMenu:
                if (buttonIndex == 0) // Start game
                {
                    StartGame();
                }
                else if (buttonIndex == 1) // Credits
                {
                    SwitchMenu(MenuScreens.Credits);
                }
                else if (buttonIndex == 2) // Exit
                {
                    ExitGame();
                }
                break;
            case MenuScreens.Credits:
                SwitchMenu(MenuScreens.MainMenu);
                break;
            default:
                break;
        }
    }

    private void StartGame(int level = 1)
    {
        print("Game started");
        SceneManager.LoadScene("Game");
    }

    private void ExitGame()
    {
        Application.Quit(0);
    }
}


// NOTE: Kan muligvis give problemer, når man giver slip på knappen, så vil værdien sænke langsomt,
// men hvis man timer det så vil den måske gå en knap videre?
/*
if (Input.GetKeyDown(KeyCode.S))
{
    VerticalMoveCanMove = false;

    // Ændrer selektion indekset baseret på om "vertical" er mindre end 0 (ned) eller mere end 0 (op).
    maxIndex += vertical < 0 ? -1 : 1;

    // Selektions indekset har overskredet minimums værdien, gå til højeste værdi.
    if (currentIndex < 0)
    {
        currentIndex = maxIndex;
    }
    else if (currentIndex > maxIndex) // Overskredet maximum værdien, gå tilbage til 0.
    {
        currentIndex = 0;
    }

    SelectNewOption(currentIndex);

    // Sætter VerticalMoveCanMove tilbage til true efter VerticalMoveTimeout millisekunder.
    StartCoroutine(MenuMoveTimeout());
}*/


// Hvad kommer efter en option
//[SerializeField] private string OptionAppend = "";

// Valgte tings blinke interval i millisekunder.
//[SerializeField] private float BlinkingInterval = 500;





// Den tærskel som man mindst skal bevæge.
//[SerializeField] private float VerticalMoveThreshold = 0.01f;

// Mindste tid i millisekunder før man kan flytte selektion. Rigtig dårlig navngivning.
//[SerializeField] private float VerticalMoveTimeout = 500;


// Select specific "button"
/*private void SelectNewOption(int buttonIndex)
{
    if (currentSelected.Length > buttonIndex && currentSelected[buttonIndex] != string.Empty)
    {
        Valgmuligheder[buttonIndex].text = OptionPrepend + currentSelected[buttonIndex];
    }
}*/
