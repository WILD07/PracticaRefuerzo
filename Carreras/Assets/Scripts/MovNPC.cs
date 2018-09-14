using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovNPC : MonoBehaviour {

    [SerializeField]
    Transform _destination;
    UnityEngine.AI.NavMeshAgent _navMeshAgent;

    // Use this for initialization
    void Start()
    {
        _navMeshAgent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.LogError("El agente de navegacion no esta añadido" + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }
    private void SetDestination()
    {
        Vector3 targetVector = _destination.transform.position;
        _navMeshAgent.SetDestination(targetVector);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
