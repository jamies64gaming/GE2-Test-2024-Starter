using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature_generator : MonoBehaviour
{
    public int length = 4;

    public float frequencyHorizontal = 1;
    
    public float frequencyVertical = 1;
    
    public float start_angle = 0;

    public float base_size = 10;

    public float multiplier = 1;

    private SpineAnimator SA;
    private NoiseWander horizontalWander;
    private Harmonic verticalWander;

    public GameObject Boid;
    // Start is called before the first frame update
    void Awake()
    {
        SA = GetComponent<SpineAnimator>();
        horizontalWander = GetComponent<NoiseWander>();
        verticalWander = GetComponent<Harmonic>();
        
        InstantiateBoids(length);
        ChangeFrequency(frequencyHorizontal,frequencyVertical);
        
    }

    void InstantiateBoids(int l)
    {
        for (int i = 0; i <= l-1; i++)
        {
            GameObject obj = Instantiate(Boid, transform.position+transform.forward , Quaternion.identity);
            SA.bones.Add(obj);
        }
    }

    void ChangeFrequency(float H, float V)
    {
        horizontalWander.frequency = H;
        verticalWander.frequency = V;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
