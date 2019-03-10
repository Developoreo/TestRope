using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public Rigidbody2D hook;
    
    public GameObject linkPrefab;
    public int links = 7;
    public List<GameObject> listLinks = new List<GameObject>();
    public LineRenderer lr;
    private void Start()
    {
        CreateRope();
    }

    private void Update()
    {
        DrawLine();

    }
    private void DrawLine()
    {
        lr.positionCount = links;
        int i;
        for (i = 0; i < listLinks.Count; i++)
        {
            lr.SetPosition(i, listLinks[i].transform.position);
        }
        
    }
    private void CreateRope()
    {
        Rigidbody2D previousRigi = hook;
      
        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            listLinks.Add(link);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();

            joint.connectedBody = previousRigi;
     
            previousRigi = link.GetComponent<Rigidbody2D>();
        }
    }
}
