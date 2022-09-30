using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI questionText;
	[SerializeField] QuestionSO question;
	[SerializeField] GameObject[] answerButtons;
	int correctAnswerIndex;
	[SerializeField] Color32 defaultAnswerColor = new Color32 (1, 1, 1, 1);
	[SerializeField] Color32 correctAnswerColor = new Color32 (1, 1, 1, 1);
	[SerializeField] Color32 wrongAnswerColor = new Color32 (1, 1, 1, 1);
	Image buttonImage;

	// Start is called before the first frame update
	void Start()
	{
		DisplayQuestion();
	}

	void DisplayQuestion()
	{
		for(int i = 0; i < answerButtons.Length; i++){
			TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
		  buttonText.text = question.GetAnswer(i);
		}
	}

	void getNextQuestion()
	{
		SetButtonState(true);
		SetDefaultColor();
		DisplayQuestion();	
	}

  void SetDefaultColor()
  {
    for(int i = 0; i < answerButtons.Length; i++){
			buttonImage = answerButtons[i].GetComponent<Image>();
			buttonImage.color = defaultAnswerColor;
		}
  }

  void SetButtonState(bool state)
	{
		for(int i = 0; i < answerButtons.Length; i++){
			Button button = answerButtons[i].GetComponent<Button>();
			button.interactable = state;
		}
	}

	public void OnAnswerSelected(int index)
	{
		
		questionText.text = question.GetQuestion();
		correctAnswerIndex = question.GetCorrectAnswerIndex();
		
		if(index == correctAnswerIndex){
			questionText.text = "Well Done!";
			buttonImage = answerButtons[index].GetComponent<Image>();
			buttonImage.color = correctAnswerColor;
		} 
		else
		{
			string correctAnswer = question.GetAnswer(correctAnswerIndex);
			questionText.text = $"Sorry, the correct answer was;\n{correctAnswer}" ;
			buttonImage = answerButtons[index].GetComponent<Image>();
			buttonImage.color = wrongAnswerColor;
		}
		SetButtonState(false);
	}
}
