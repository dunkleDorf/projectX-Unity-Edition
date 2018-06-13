using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour {
    void loadlevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoginToMenu() {
        loadlevel("menu_scene");
    }
    public void MenuToPDF() {
        loadlevel("pdf_scene");
    }
}
