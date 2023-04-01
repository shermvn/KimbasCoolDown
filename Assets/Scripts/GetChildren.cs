using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChildren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //get children
       // List<Transform> children = GetChild(transform, false);

        //get children recursively
        List<Transform> children = GetChild(transform, true);
        foreach (Transform child in children)
        {
            Debug.Log(child.name);
        }
    }

    List<Transform> GetChild(Transform parent, bool recursive)
    {
        List<Transform> children = new List<Transform>();
        foreach(Transform child in parent)
        {
            children.Add(child);
            if(recursive)
            {
                children.AddRange(GetChild(child, true));
            }
        }
        return children;
    }
}
