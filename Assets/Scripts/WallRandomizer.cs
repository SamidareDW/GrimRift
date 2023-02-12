using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRandomizer : MonoBehaviour
{

    
    
    public GameObject Wall1, Wall2, Wall3, Wall4;
    List<Mesh> WallFilters = new List<Mesh>();
    public Mesh wallMesh1;
    public Mesh wallMesh2;
    public Mesh wallMesh3;
    public Mesh wallMesh4;
    
    
    void Start()
    {
      /*  WallFilters.Add(wallMesh1);
        WallFilters.Add(wallMesh2);
        WallFilters.Add(wallMesh3);
        WallFilters.Add(wallMesh4);
        
        Wall1.transform.localScale = new Vector3(1,1,Random.Range(0.8f, 1.0f));
        Wall2.transform.localScale = new Vector3(1,1,Random.Range(0.8f, 1.0f));
        Wall3.transform.localScale = new Vector3(1,1,Random.Range(0.8f, 1.0f));
        Wall4.transform.localScale = new Vector3(1,1,Random.Range(0.8f, 1.0f));
        

        Wall1.gameObject.AddComponent<MeshFilter>().mesh = WallFilters [Random.Range(0, WallFilters.Count)];
        Wall2.gameObject.AddComponent<MeshFilter>().mesh = WallFilters [Random.Range(0, WallFilters.Count)];
        Wall3.gameObject.AddComponent<MeshFilter>().mesh = WallFilters [Random.Range(0, WallFilters.Count)];
        Wall4.gameObject.AddComponent<MeshFilter>().mesh = WallFilters [Random.Range(0, WallFilters.Count)];*/

    }

    public void RandomizeWalls()
    {
        WallFilters.Add(wallMesh1);
        WallFilters.Add(wallMesh2);
        WallFilters.Add(wallMesh3);
        WallFilters.Add(wallMesh4);
        
        Wall1.transform.localScale = new Vector3(1,1,Random.Range(0.8f, 1.0f));
        Wall2.transform.localScale = new Vector3(1,1,Random.Range(0.8f, 1.0f));
        Wall3.transform.localScale = new Vector3(1,1,Random.Range(0.8f, 1.0f));
        Wall4.transform.localScale = new Vector3(1,1,Random.Range(0.8f, 1.0f));
        

        Wall1.gameObject.AddComponent<MeshFilter>().mesh = WallFilters [Random.Range(0, WallFilters.Count)];
        Wall2.gameObject.AddComponent<MeshFilter>().mesh = WallFilters [Random.Range(0, WallFilters.Count)];
        Wall3.gameObject.AddComponent<MeshFilter>().mesh = WallFilters [Random.Range(0, WallFilters.Count)];
        Wall4.gameObject.AddComponent<MeshFilter>().mesh = WallFilters [Random.Range(0, WallFilters.Count)];
    } 
    
}
