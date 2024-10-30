using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;
    void Start() {
        Cursor.visible = false;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            if(!pauseMenu.activeSelf) {
                Debug.Log("pause");
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
            } else {
                Debug.Log("un-pause");
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                Cursor.visible = false;
            }
        }
    }

    public void quit() {
        Application.Quit();
    }

    public void menu() {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void resume() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }
}
