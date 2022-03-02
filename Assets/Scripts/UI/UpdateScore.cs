using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour, IObserver<Observer.OnScoreUpdateInfo>
{
    [SerializeField]
    private int basicScore = 0;
    [SerializeField]
    public void Response(Observer.OnScoreUpdateInfo info)
    {
        TextMeshProUGUI scoreText = GetComponent<TextMeshProUGUI>();
        basicScore += info.score;
        scoreText.text = "Current Score " + basicScore.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
