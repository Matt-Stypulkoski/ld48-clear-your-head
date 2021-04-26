using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtController : MonoBehaviour
{

    public GameObject path;
    [SerializeField]
    List<Transform> pathNodes;
    Rigidbody2D rb;
    [SerializeField]
    public Vector3 currTargetNode;
    [SerializeField]
    public int targetNodeIndex = 0;
    [SerializeField]
    float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in path.GetComponentInChildren<Transform>()) {
            pathNodes.Add(child);
        }

        currTargetNode = pathNodes[0].position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == currTargetNode) {
            targetNodeIndex = getNextIndex(pathNodes, targetNodeIndex);
            currTargetNode = getNextPosition(pathNodes, targetNodeIndex);
        }
    }

    private void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, currTargetNode, speed * Time.fixedDeltaTime);
    }

    int getNextIndex(List<Transform> nodes, int lastNodeIndex) {
        int newNodeIndex = lastNodeIndex + 1;
        if (nodes.Count <= newNodeIndex) {
            newNodeIndex = 0;
        }
        return newNodeIndex;
    }

    Vector3 getNextPosition(List<Transform> nodes, int newIndex) {
        return nodes[newIndex].transform.position;
    }
}
