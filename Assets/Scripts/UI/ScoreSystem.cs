using UnityEngine;
using UnityEngine.UIElements;

// 分数 逻辑 与 展示

public class ScoreSystem : MonoBehaviour
{
    public float scoreMultiplier = 10f;
    public UIDocument uiDocument;

    private Label scoreText;
    private float elapsedTime;
    private int lastShownScore = -1;

    void Awake()
    {
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);

        // 只有分数变化时才刷新 UI，避免每帧写字符串
        if (score == lastShownScore) return;
        lastShownScore = score;
        scoreText.text = $"Score: {score}";
    }
}