using UnityEngine;

public class BugAnimRigging : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Animator>().Rebind();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
