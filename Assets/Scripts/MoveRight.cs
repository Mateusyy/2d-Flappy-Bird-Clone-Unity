using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour {

    public float speed = 1f;

	// Update is called once per frame
	void Update () {
        if(FindObjectOfType<GameManager>().isGame)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}
