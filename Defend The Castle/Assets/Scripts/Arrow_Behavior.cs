using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Behavior : MonoBehaviour
{
    [SerializeField]
    public GameObject arrow_reference;

    private Vector3 targetPosition;

    private float moveSpeed = 10f;

    public void Create(Vector3 spawnPosition, Vector3 targetPosition)
    {
        GameObject projectileArrow = Instantiate(arrow_reference);
        projectileArrow.transform.position = spawnPosition;
        Arrow_Behavior AB = projectileArrow.GetComponent<Arrow_Behavior>();
        AB.Setup(targetPosition);

    }

    public void Setup(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if(Vector3.Distance(transform.position, transform.position) < 1f )
        {
            Destroy(gameObject);
        }
        
    }
}
