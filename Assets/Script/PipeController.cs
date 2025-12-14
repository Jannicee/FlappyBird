using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : ObstacleBase
{
    public override void Move()
    {
        Vector2 newPosition = transform.position;
        newPosition.x -= speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
