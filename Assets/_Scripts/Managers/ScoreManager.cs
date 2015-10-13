using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public static int score;
	
	
	public Text text;
	
	
	void Awake()
	{
		text = GetComponent <Text> ();
		score = 0;
	}
	
	
	void Update ()
	{
//		Debug.Log (text.text);
		text.text = "Score: " + score;
		//Debug.Log (text.text);
		//Debug.Log (stext);
		//stext.text="Score";
	}
}