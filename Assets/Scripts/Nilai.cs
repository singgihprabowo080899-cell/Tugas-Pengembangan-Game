using UnityEngine;
using TMPro;

public class Nilai : MonoBehaviour
{
    public static Nilai Instance;

    [SerializeField] private TextMeshProUGUI _nilai;
    [SerializeField] private TextMeshProUGUI _terbaik;

    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void Start()
    {
        _score = 0;
        _nilai.text = _score.ToString();

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        _terbaik.text = bestScore.ToString();
    }

    public void UpdateBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (_score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", _score);
            _terbaik.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _nilai.text = _score.ToString();
        UpdateBestScore();
    }
}
