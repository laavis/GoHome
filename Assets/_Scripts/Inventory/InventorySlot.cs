using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public Image icon;

	private Image img;
	private Button btn;

	Item item;

	void Awake (){
		img = gameObject.GetComponent<Image>();
		btn = gameObject.GetComponent<Button>();
	}

	public void AddItem (Item newItem){
		item = newItem;

		img.enabled = true;
		btn.enabled = true;

		icon.sprite = item.icon;
		icon.enabled = true;
	}

}
