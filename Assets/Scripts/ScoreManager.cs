using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score;
    private List<IScoreObserver> observers = new List<IScoreObserver>();

    void Awake()
    {
        Instance = this;
    }

    public void AddObserver(IScoreObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IScoreObserver observer)
    {
        observers.Remove(observer);
    }

    public void UpdateScore(int deltaScore)
    {
        score += deltaScore;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnScoreUpdated(score);
        }
    }
}

public interface IScoreObserver
{
    void OnScoreUpdated(int score);
}
