using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


// UI 文件
// UI - 重启按钮
public class GameManager : MonoBehaviour
{
    public UIDocument uiDocument;

    private Button restartButton;

    void Awake()
    {
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
    }

    // 供 PlayerController 在爆炸时调用
    public void ShowRestartButton()
    {
        restartButton.style.display = DisplayStyle.Flex;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}