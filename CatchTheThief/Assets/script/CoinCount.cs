using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour {

	public static int coins;
	public static Text coinText; 

	void Start () {
		coinText = GetComponent<Text>();
		coins = 0;
		UpdateCoin (0);
	}

	public static void UpdateCoin (int num) {
		coins += num;
		coinText.text = coins.ToString ();
	}
}
