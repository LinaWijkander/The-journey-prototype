 using System;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 using UnityEngine.UIElements;
 
[RequireComponent(typeof(UIDocument))]
 public class UISample : MonoBehaviour/*Observer*/ // Observes Player. Registered as an observer there
 {
     private UIDocument uiDocument;
     private Label coreHealthValueLabel;
     private Label waveValueLabel;
     private VisualElement gameOverPanel;     
     private VisualElement gameWonPanel;
     private Button retryButton;
     
     public void OnEnable()
     {
         Initialize();
         //Player.CoreHealthLostEvent += OnCoreHealthLost;  // ska vara decoupled, men vad sker om player försvinner?
     }

     private void Start()//cant have the non static events in enable. null ref error. on gamemanager or event
     //static instances at compile time
     {
         //GameManager.Instance.enemyManager.NewWaveEvent += OnNewWave;
         //GameManager.Instance.enemyManager.WinGameEvent += OnGameWon;
         //GameManager.Instance.GameOverEvent += OnGameOver;
     }

     private void OnDestroy()
     {
         //Player.CoreHealthLostEvent -= OnCoreHealthLost;
         //GameManager.Instance.enemyManager.NewWaveEvent -= OnNewWave;
         //GameManager.Instance.GameOverEvent -= OnGameOver;
         //GameManager.Instance.enemyManager.WinGameEvent -= OnGameWon;
     }

     private void Initialize()
     {
         uiDocument = GetComponent<UIDocument>();
         VisualElement root = uiDocument.rootVisualElement;
         gameOverPanel = root.Q<VisualElement>("GameOverPanel");
         gameWonPanel = root.Q<VisualElement>("GameWonPanel");
         gameOverPanel.style.display = DisplayStyle.None;
         gameWonPanel.style.display = DisplayStyle.None;
         coreHealthValueLabel = root.Q<Label>("CoreHealthValue");
         waveValueLabel = root.Q<Label>("WaveValue");
         retryButton = root.Q<Button>("RetryButton");

         retryButton.clickable.clicked += RestartGame;
     }

     private void OnCoreHealthLost(int coreHealthToDisplay)
     {
         coreHealthValueLabel.text = coreHealthToDisplay.ToString();
     }
     
     private void OnNewWave(int waveToDisplay)
     {
         waveValueLabel.text = waveToDisplay.ToString();
     }

     private void OnGameOver(/*Player player*/)
     {
         // Depending on what player - display that player's game over screen & end the game
         gameOverPanel.style.display = DisplayStyle.Flex;
         // Ok button to start screen
         // have ui block other input
     }

     private void OnGameWon(bool player) // todo have what player won
     {
         gameWonPanel.style.display = DisplayStyle.Flex;
     }

     private void RestartGame()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
     
    // refreshButton.clicked += () => RefreshMicrophones(root);
    // microphoneLabel = root.Q<Label>("SelectedMicrophone");
    // RefreshMicrophones(root);
    // }

    // private void RefreshMicrophones(VisualElement root)
    // {
    // Debug.Log("Refreshing microphones");
    // ScrollView microphoneRoot = root.Q<ScrollView>("MicrophoneParent");
    // var enumerator = Recorder.PhotonMicrophoneEnumerator;
    // if (enumerator.IsSupported)
    // {
    // string selectedMicrophone = PlayerPrefs.GetString(Consts.Microphone);
    // bool selectedMicrophoneFound = false;
    // microphoneRoot.Clear();
    // for (int i = 0; i < enumerator.Count; i++)
    // {
    // Debug.LogFormat("PhotonMicrophone Index={0} ID={1} Name={2}", i,
    // enumerator.IDAtIndex(i),
    // enumerator.NameAtIndex(i));
    //
    // string microphoneName = enumerator.NameAtIndex(i);
    // Button microphoneButton = new Button(() => SetMicrophone(microphoneName)) {text
    // = microphoneName};
    // microphoneRoot.Add(microphoneButton);
 }
