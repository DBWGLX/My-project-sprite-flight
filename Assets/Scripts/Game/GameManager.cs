using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


// UI 文件
// UI - 重启按钮
public class GameManager : MonoBehaviour
{
    public UIDocument uiDocument;

    private Button restartButton;

    private Button returnMainMenuButton;

    void Awake()
    {
        // 获取 UI 按钮
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        returnMainMenuButton = uiDocument.rootVisualElement.Q<Button>("MainMenuButton");

        // 游戏开始时隐藏按钮
        restartButton.style.display = DisplayStyle.None;
        returnMainMenuButton.style.display = DisplayStyle.None;

        // 注册点击事件
        restartButton.clicked += ReloadScene;
        returnMainMenuButton.clicked += ReturnMenuScene;
    }

    // 供 PlayerController 在爆炸时调用
    public void ShowRestartButton()
    {
        restartButton.style.display = DisplayStyle.Flex;
        returnMainMenuButton.style.display = DisplayStyle.Flex;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ReturnMenuScene(){
        SceneManager.LoadScene("MainMenu");
    }


}