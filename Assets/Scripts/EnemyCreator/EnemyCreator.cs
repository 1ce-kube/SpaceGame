using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    // public EnemyCreator EC;
    public GameObject Rocktype_1;
    public GameObject Rocktype_2;
    public GameObject Rocktype_3;
    private GameObject erock;
    public GameObject score;
    public float Ems = 10f; // Enemy Move Speed
    private bool isenemy = false;
    public bool EnemyCreate = true;
    public int points = 0;
    [SerializeField]public TMPro.TextMeshProUGUI _title;
    private int counter = 0;

    public void Start(){
        Ems = 10f;
        if (EnemyCreate){
            CreateEnemy();
        }
    }

    public void Update(){
        if (isenemy){
            erock.transform.position = Vector3.MoveTowards(erock.transform.position, new Vector3 (-13,  erock.transform.position.y, 0), Ems * Time.deltaTime); // 
            if (erock.transform.position.x <= -13){
                isenemy = false;
            }
        } else {
            Destroy(erock);
            if (EnemyCreate){
                if (Ems < 70){
                    Ems += 0.1f;
                }
                counter = counter + 1;
                _title.text = "Points: " + counter;
                CreateEnemy();
            } else {
                
            }
        }
    }
    
    // private int RandomNumber(){
    //     Random rand = new Random();
    //     double min = -3.0f;
    //     double max = 3.0f;
    //     double range = max - min;
    //     double sample = rand.NextDouble();
    //     double scaled = (sample * range) + min;
    //     float f = (float)scaled;
    //     return (float)scaled;
    // }
    // private double RandomNumber(double minimum, double maximum){ 
    //     Random random = new Random();
    //     return random.NextDouble() * (maximum - minimum) + minimum;
    // }

    static float RandomNumber(float min, float max){
        System. Random random = new System. Random();
        double val = (random. NextDouble() * (max - min) + min);
        return (float)val;
    }

    private void CreateEnemy(){
        List<GameObject> rocks = new List<GameObject>() {Rocktype_1, Rocktype_2, Rocktype_3};
        System. Random rand = new System. Random();
        int indx = rand.Next(rocks.Count);
        GameObject type = rocks[indx];
        
        erock = Instantiate(type,  new Vector3(13, RandomNumber(-3f, 3f), 0), transform.rotation) as GameObject;
        // erock.AddComponent(typeof(SphereCollider));
        erock.transform.rotation = type.transform.rotation;
        isenemy = true;

        // for (int i = 0; i < 1; i++){
        // }
        // while (erock.transform.position.x > -13){
        //     erock.transform.Translate(erock.transform.position.x + 0.001f, erock.transform.position.y, 0);
        // }
        // Destroy(erock);
        // erock.transform.Translate(erock.transform.position.x + 0.001f, erock.transform.position.y, 0);
        // Vector3 tPoint = ; // Указываешь нужные координаты
    }

    void OnCollisionEnter(Collision other){
        print(1);
        EnemyCreate = false;
        isenemy = false;
    }
}