using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {


    //public GameObject part;
    //public Sprite block_org;
    //public Sprite block_left;
    //public Sprite block_right;

    public Transform generationPoint;

    [SerializeField]
    private float partWidth = 4f;
    public GameObject[] gameElements;


    [HideInInspector]
    public int index;

    private string partTag = "PlatformGame";
    private string enemyPartTag = "EnemyPlatformGame";



    Transform myChild;
    Transform partOfPlatform;

    private void Start() {
        if (gameElements.Length <= 0) {
            Debug.LogError("MapGeneration: list of gameElements is empty!");
        }
        index = 0;
    }

    private void Update() {
        if (generationPoint.position.x > transform.position.x) {
            transform.position = new Vector3(transform.position.x + partWidth, transform.position.y, transform.position.z);

            GeneratePart();
        }
    }

    void GeneratePart() {
        index++;
        if (index > 2) index = 0;

        GameObject partGO = gameElements[index];
        partGO.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


        for (int i = 0; i < 4; i++) {
            int num_1 = Random.Range(4, 8);

            for (int j = 0; j < 10; j++) {
                myChild = partGO.gameObject.transform.GetChild(i);
                partOfPlatform = myChild.gameObject.transform.GetChild(j);


                //partOfPlatform.GetComponent<SpriteRenderer>().sprite = block_org;
                if (j == num_1 || j == num_1 + 1 || j == num_1 -1) {
                    partOfPlatform.gameObject.SetActive(false);
                } else {
                    if (!partOfPlatform.gameObject.activeSelf) {
                        partOfPlatform.gameObject.SetActive(true);


                        //partOfPlatform.tag = partTag;
                    }
                }

                /*if (j == num_1 - 1)
                    partOfPlatform.GetComponent<SpriteRenderer>().sprite = block_right;
                if (j == num_1 + 2)
                    partOfPlatform.GetComponent<SpriteRenderer>().sprite = block_left;

                if (num_1 - 1 < 0) {
                    if (j == 9)
                        partOfPlatform.GetComponent<SpriteRenderer>().sprite = block_right;
                }*/
            }
        }
    }
}
