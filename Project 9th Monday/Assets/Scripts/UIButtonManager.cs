using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour {

    [Header("Groupings")]
    [SerializeField] private GameObject mainButtons;
    [SerializeField] private GameObject confirmExit, confirmRestart;

    [Header("Buttons")]
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private List<UIButton> allButtons;

    // --------------------------------------------------------------------

    public void CancelConfirmation() {
        mainButtons.SetActive(true);
        confirmExit.SetActive(false);
        confirmRestart.SetActive(false);
        ResetAllButtons();
    }

    private void ResetAllButtons() {
        foreach(UIButton button in allButtons)
            button.ResetColor();
    }

    // --------------------------------------------------------------------

    public void OpenExitConfirm() {
        mainButtons.SetActive(false);
        confirmExit.SetActive(true);
        ResetAllButtons();
    }

    public void ExitGame() {
        Debug.Log("Exiting application");
        Application.Quit();
    }

    // --------------------------------------------------------------------

    public void OpenRestartConfirm() {
        mainButtons.SetActive(false);
        confirmRestart.SetActive(true);
        ResetAllButtons();
    }

    public void RestartGame() {
        Debug.Log("Restarting game");
        SceneManager.LoadScene(0);
    }

    // --------------------------------------------------------------------

    public void PauseGame() {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
    }

    public void UnpauseGame() {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

}
