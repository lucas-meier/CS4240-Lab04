using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour, IObserver<int>
{
    [SerializeField]
    private int basicScore = 0;
    [SerializeField]
    public void Response(int score)
    {
        TextMeshProUGUI scoreText = GetComponent<TextMeshProUGUI>();
        basicScore += score;
        scoreText.text = "Current Score " + basicScore.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        Response(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
