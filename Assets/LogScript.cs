using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    public float speed = 0f;
    public Vector3 direction = Vector3.left;

    public float random_speed_offset_magnitude = .5f;

    public Vector3 spawn_center;

    public float max_distance;
    // Start is called before the first frame update
    void Start()
    {
        // Randomly changes speed (second term to center translation around 0)
        speed += (random_speed_offset_magnitude * Random.value) - random_speed_offset_magnitude / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, spawn_center) >= max_distance)
        {
            _die();
        }
    }

    void _die()
    {
        Destroy(this.gameObject);
    }
}
