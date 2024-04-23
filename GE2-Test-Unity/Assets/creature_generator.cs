using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class creature_generator : MonoBehaviour
{
    public int length = 4;

    public float frequency = 1;
    
    public float start_angle = 0;

    public Vector3 base_size = new Vector3(1,1,1);

    public float multiplier = 1;

    private SpineAnimator SA;
    private NoiseWander horizontalWander;
    private Harmonic verticalWander;
    private Boid B;

    public GameObject Boid;
    // Start is called before the first frame update
    void Awake()
    {
        SA = GetComponent<SpineAnimator>();
        horizontalWander = GetComponent<NoiseWander>();
        verticalWander = GetComponent<Harmonic>();
        B = GetComponent<Boid>();
        
        SetMassAndSize(base_size);
        InstantiateBoids(length);

        Time.timeScale = 0;

    }

    void InstantiateBoids(int l)
    {
        for (int i = 1; i < l; i++)
        {
            Vector3 Lsize = base_size*Mathf.Sin(frequency*i+start_angle*multiplier);
            Lsize.x = Mathf.Abs(Lsize.x);
            Lsize.y = Mathf.Abs(Lsize.y);
            Lsize.z = Mathf.Abs(Lsize.z);
            GameObject obj = Instantiate(Boid, transform.position-transform.forward * (i*2), transform.rotation);
            obj.transform.localScale = Lsize;
            SA.bones.Add(obj);
        }
    }
    

    void SetMassAndSize(Vector3 size)
    {
        B.mass = size.x * size.y * size.z;
        transform.localScale = size;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else if(Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
    }

    void DrawGizmo()
    {
        print("hi");
    }
}
