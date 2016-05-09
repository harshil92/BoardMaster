using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	Color [] color = new Color[]{Color.yellow, Color.red, Color.green, Color.blue, Color.cyan} ;
	string [] colorName = new string[]{"yellow", "red", "green", "blue", "cyan"};

	[SerializeField]
	private Text question = null;
	[SerializeField]
	private Text scoreText = null;
	[SerializeField]
	private Text[] options = new Text[2];
    [SerializeField]
    private Text timerText = null;

    float timeLeft = 3.0f;


    Color currColor ;
	string currColorName = "";
	int optionNum=0; 
	int currColorNum=0; 
	int currColorNameNum=0; 
	int score = 0;
	// Use this for initialization

	public ColorBlock colorBlock;
	public ColorBlock colorBlock2;

	void Start () {
		
		currColorNum = Random.Range (0, 5); 
		currColorNameNum = Random.Range (0, 5); 
		while (currColorNum == currColorNameNum) {
			currColorNameNum = Random.Range (0, 5);
		}
		currColor = color [currColorNum];

		currColorName = colorName [currColorNameNum];

		question.text = currColorName;
		question.color = currColor;



		optionNum = Random.Range (0, 2);

		options [optionNum].text = currColorName;

		Button b = options [optionNum].GetComponentInParent<Button> ();
		colorBlock = b.colors;
		colorBlock.normalColor = color [currColorNum];
		colorBlock.pressedColor = color [currColorNum];
		colorBlock.highlightedColor = color [currColorNum];
		b.colors = colorBlock;


		if (optionNum == 0) {
			options [1].text = colorName[currColorNum];
			Button c = options [1].GetComponentInParent<Button> ();
			colorBlock2 = c.colors;
			colorBlock2.normalColor = color [currColorNameNum];
			colorBlock2.pressedColor = color [currColorNameNum];
			colorBlock2.highlightedColor = color [currColorNameNum];
			c.colors = colorBlock2;

		} else {
			options [0].text = colorName[currColorNum];
			Button c = options [0].GetComponentInParent<Button> ();
			colorBlock2 = c.colors;
			colorBlock2.normalColor = color [currColorNameNum];
			colorBlock2.pressedColor = color [currColorNameNum];
			colorBlock2.highlightedColor = color [currColorNameNum];
			c.colors = colorBlock2;
		}

		options [0].GetComponentInParent<Button> ().onClick.AddListener(() => {
			
			check(options[0].text);

		});

		options [1].GetComponentInParent<Button> ().onClick.AddListener(() => {
			check(options[1].text);
		});


	}

	void check(string text){
		if(colorName[currColorNum] == text){
			Debug.Log ("Corret");
			++score;
			scoreText.text = score.ToString();
			//ADD POINTS
			reset();
            timeLeft = 3.0f;
        }
        else {
			Debug.Log ("wrong");
			//Reset screen
			reset();
            timeLeft = 3.0f;
		}
	}

	void reset(){
		currColorNum = Random.Range (0, 5); 
		currColorNameNum = Random.Range (0, 5); 
		while (currColorNum == currColorNameNum) {
			currColorNameNum = Random.Range (0, 5);
		}
		currColor = color [currColorNum];

		currColorName = colorName [currColorNameNum];

		question.text = currColorName;
		question.color = currColor;



		optionNum = Random.Range (0, 2);

		options [optionNum].text = currColorName;

		Button b = options [optionNum].GetComponentInParent<Button> ();
		colorBlock = b.colors;
		int ranNum = Random.Range (0, 5);
		colorBlock.normalColor = color [ranNum];
		colorBlock.pressedColor = color [ranNum];
		colorBlock.highlightedColor = color [ranNum];
		b.colors = colorBlock;


		if (optionNum == 0) {
			options [1].text = colorName[currColorNum];
			Button c = options [1].GetComponentInParent<Button> ();
			colorBlock2 = c.colors;
			colorBlock2.normalColor = color [currColorNameNum];
			colorBlock2.pressedColor = color [currColorNameNum];
			colorBlock2.highlightedColor = color [currColorNameNum];
			c.colors = colorBlock2;

		} else {
			options [0].text = colorName[currColorNum];
			Button c = options [0].GetComponentInParent<Button> ();
			colorBlock2 = c.colors;
			colorBlock2.normalColor = color [currColorNameNum];
			colorBlock2.pressedColor = color [currColorNameNum];
			colorBlock2.highlightedColor = color [currColorNameNum];
			c.colors = colorBlock2;
		}

	}


    void Update()
    {
        timeLeft -= Time.deltaTime;
        

        if (timeLeft < 0)
        {
            reset();
            timeLeft = 3.0f;


        }
        timerText.text = timeLeft.ToString();
    }


}
