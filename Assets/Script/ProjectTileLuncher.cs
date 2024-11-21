using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileLuncher : MonoBehaviour
{
    public Transform lunchPoint;
    public GameObject projectilePrefab;
    public void FireProjetctile()
    {
       GameObject projecttile = Instantiate(projectilePrefab, lunchPoint.position, projectilePrefab.transform.rotation);
        Vector3 origScale = projecttile.transform.localScale;
        projecttile.transform.localScale = new Vector3(
            origScale.x * transform.localScale.x > 0 ? 1 : -1,

            origScale.y,


            origScale.z
            );
    }
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
