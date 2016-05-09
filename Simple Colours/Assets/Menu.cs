using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {
	[SerializeField]
	private Button play = null;
	[SerializeField]
	private Button sound = null;
	[SerializeField]
	private Button score = null;
	// Use this for initialization
	void Start () {
		play.onClick.AddListener(() => {

			Application.LoadLevel(1);

		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
