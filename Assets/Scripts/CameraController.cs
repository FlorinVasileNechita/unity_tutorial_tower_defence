using UnityEngine;

public class CameraController : MonoBehaviour {

	private bool doMovement = true;

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;

	public float scrollSpeed = 5f;

	public float minY = 10f;
	public float maxY = 80f;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
			doMovement = !doMovement;
		}

		if (!doMovement) {
			return;
		}
		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			transform.Translate (new Vector3(1f,0f,0f) * -panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) {
			transform.Translate (new Vector3(1f,0f,0f) * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) {
			transform.Translate (new Vector3(0f,0f,1f) * -panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
			transform.Translate (new Vector3(0f,0f,1f) * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

		pos.y = Mathf.Clamp (pos.y, minY, maxY);

		Debug.Log (pos.y);

		transform.position = pos;

	}
}
