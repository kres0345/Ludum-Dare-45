using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject loadingPanal;
    public bool sceneLoaded { private set; get; } = false;
    public TextMeshProUGUI finishedLoading;
    public string finishedLoadingString;
    public float BlinkingInterval;

    [Header("Progress bar")]
    public TextMeshProUGUI loadingProgressbar;
    public char progressbarFill = '#';
    public char progressbarEmpty = ' ';
    [Tooltip("'%s' er der hvor fill og empty kommer til at være")]
    public string progressbarText;
    [Tooltip("Bredde i form af antal tegn")]
    [Range(0, 100)] public int progressbarWidth;

    private string fillReplacement = "%s";
    private GameObject gameController;
    private bool AwaitingAnybutton = false;

    void Awake()
    {
        Time.timeScale = 0;
        LoadLevel(0);
    }

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        if (Input.anyKeyDown && sceneLoaded && AwaitingAnybutton)
        {
            loadingPanal.SetActive(false);

            Time.timeScale = 1.0f;
            AwaitingAnybutton = false;
        }
    }

    // Does not support scenes with indexes higher than 10. Or is it 9? Anyways...
    public void LoadLevel(int levelId)
    {
        //SceneManager.LoadSceneAsync("Level0" + levelId, LoadSceneMode.Additive);
        StartCoroutine(LoadSceneAsync("Level0" + levelId));
    }

    IEnumerator LoadSceneAsync(string scenename)
    {
        loadingPanal.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenename, LoadSceneMode.Additive);

        int totalSpace;
        do {
            totalSpace = progressbarWidth - (progressbarText.Length - fillReplacement.Length);
            int fillLength = Mathf.FloorToInt(asyncLoad.progress * totalSpace);
            int emptyLength = totalSpace - fillLength;
            string text = progressbarText.Replace(fillReplacement, new string(progressbarFill, fillLength) + new string(progressbarEmpty, emptyLength));
            loadingProgressbar.text = text;

            yield return null; // Venter en frame.
        }
        while (!asyncLoad.isDone); //!asyncLoad.isDone
        loadingProgressbar.text = progressbarText.Replace(fillReplacement, new string(progressbarFill, totalSpace));


        // Set player spawn
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("Spawnpoint");
        Vector2 SpawnPosition = new Vector2(0, 0);

        if (spawnPoint != null)
        {
            SpawnPosition = spawnPoint.transform.position;
        }
        player.transform.position = SpawnPosition;

        sceneLoaded = true;
        finishedLoading.text = finishedLoadingString;

        AwaitingAnybutton = true;
        StartCoroutine(BlinkingLine());
    }

    IEnumerator BlinkingLine()
    {
        while (AwaitingAnybutton)
        {
            yield return new WaitForSecondsRealtime(BlinkingInterval / 1000);
            finishedLoading.alpha = 0;
            yield return new WaitForSecondsRealtime(BlinkingInterval / 1000);
            finishedLoading.alpha = 1;
        }
    }
}
