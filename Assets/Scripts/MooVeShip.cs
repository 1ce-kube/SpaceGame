using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using EnemyCreator;

public class MooVeShip : MonoBehaviour{
    public EnemyCreator EnemyCreator_var;
    public float speed = 0.001f;
    public bool invisible = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ship movement: -3.0 – 3.0
        if (Input.GetKey(KeyCode.UpArrow) & this.transform.position.y <= 3.0){
            this.transform.Translate(0, speed, 0);
        } else if (Input.GetKey(KeyCode.DownArrow) & this.transform.position.y >= -3.0){
            this.transform.Translate(0, -speed, 0);
        }
    }

    void OnCollisionEnter(Collision other){
        List<string> names = new List<string>() {"rock_type_1", "rock_type_2", "rock_type_3"};
        string enemyname = other.gameObject.name;
        if (!invisible){
            // MonoBehaviour n = (GameObject.Find("Main Camera").transform.GetComponent<EnemyCreator>() as MonoBehaviour);
            // var n = EnemyCreator();
            EnemyCreator_var.EnemyCreate = false;
            // n.ECD(false);
            print("Game Over!");
        }
    }
}
