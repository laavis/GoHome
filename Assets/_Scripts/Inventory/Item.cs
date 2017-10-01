using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
	new public string name = "New Name";
	public Sprite icon = null;
	[TextArea]
	public string description;
}
