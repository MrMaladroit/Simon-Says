using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _blueOption;
    [SerializeField] private GameObject _yellowOption;
    [SerializeField] private GameObject _redOption;
    [SerializeField] private GameObject _greenOption;
    [SerializeField] private int patternLength = 15;
    [SerializeField] private UIScoreText UIScoreText;



    private int _currentStreak;
    private bool isWaitingForInput = false;

    private List<GameObject> _currentPattern = new List<GameObject>();
    private List<GameObject> _playerInputPattern = new List<GameObject>();

    private void Start()
    {
        GeneratePattern();
        UIScoreText.SetCurrentStreakText(_currentStreak);
        UIScoreText.SetHighscoreText(_currentStreak);
    }

    private void Update()
    {
        if(isWaitingForInput)
        {
            GetPlayerInput();
        }
        else
        {
            IsGameOver();
            PlayPatternAnimation();
        }
    }

    private void GetPlayerInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            _playerInputPattern.Add(hitInfo.collider.gameObject);
            isWaitingForInput = false;
        }
    }

    private void IsGameOver()
    {
        if(_currentPattern.Equals(_playerInputPattern) && _currentPattern.Count < patternLength)
        {
            _currentStreak++;
            UIScoreText.SetCurrentStreakText(_currentStreak);
            return;
        }
        else if(_currentPattern.Count >= patternLength)
        {
            // Transistion to Win Screen
        }
        else
        {
            // Transition to Lose Screen
        }
    }

    private void PlayPatternAnimation()
    {
        int iteration = 1;
        foreach (GameObject obj in _currentPattern)
        {
            OptionsController optionsController = obj.GetComponent<OptionsController>();
            StartCoroutine(optionsController.LightUpForTwoSeconds());

            iteration++;
            if (iteration > _currentStreak)
            {
                break;
            }
        }
    }


    private void GeneratePattern()
    {
        for (int iteration = 0; iteration < patternLength; iteration++)
        {
            int randomNumber = UnityEngine.Random.Range(1, 100);
            switch(randomNumber % 4)
            {
                case 0:
                    {
                        _currentPattern.Add(_blueOption);
                        break;
                    }
                case 1:
                    {
                        _currentPattern.Add(_yellowOption);
                        break;
                    }
                case 2:
                    {
                        _currentPattern.Add(_redOption);
                        break;
                    }
                case 3:
                    {
                        _currentPattern.Add(_greenOption);
                        break;
                    }
                default:
                    {
                        Debug.LogError(randomNumber % 4 + "fell through switch");
                        break;
                    }
            }
        }
    }
}