using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveNodesOnRun : MonoBehaviour
{
    [SerializeField]
    GameObject[] pathNodes;

    // Start is called before the first frame update
    void Start()
    {
        pathNodes = GameObject.FindGameObjectsWithTag("PathNode");
        foreach (GameObject node in pathNodes) {
            node.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
