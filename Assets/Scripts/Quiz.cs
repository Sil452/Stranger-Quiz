using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI questionText;
	[SerializeField] QuestionSO question;
	[SerializeField] GameObject[] answerButtons;
	int correctAnswerIndex;
	[SerializeField] Color32 defaultAnswerColor = new Color32 (1, 1, 1, 1);
	[SerializeField] Color32 correctAnswerColor = new Color32 (1, 1, 1, 1);
	[SerializeField] Color32 wrongAnswerColor = new Color32 (1, 1, 1, 1);

	// Start is called before the first frame update
	void Start()
	{
		questionText.text = question.GetQuestion();
		correctAnswerIndex = question.GetCorrectAnswerIndex();
		for(int i = 0; i < answerButtons.Length; i++){
			TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
		  buttonText.text = question.GetAnswer(i);
		}
	}

	public void OnAnswerSelected(int index)
	{
		if(index == correctAnswerIndex){
			questionText.text = "Well Done!";
			Image buttonImage = answerButtons[index].GetComponent<Image>();
			buttonImage.color = correctAnswerColor;
		} 
		else
		{
			string correctAnswer = question.answers[correctAnswerIndex];
			questionText.text = $"Sorry, the correct answer was;\n{correctAnswer}" ;
			Image buttonImage = answerButtons[index].GetComponent<Image>();
			buttonImage.color = wrongAnswerColor;
		}
	}
}
