using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MovingPath : MonoBehaviour
{
    public enum PathTypes
    {
        linear ,
        loop
    }

    public PathTypes PathType;
    public int movementDirection = 1;
    public int MoveingTo = 0;
    public Transform[] PathElements;

    public void OnDrawGizmos()
    {
        if (PathElements == null ||  PathElements.Length < 2)
        {
            return;
        }
        for (var i = 0; i < PathElements.Length; i++)
            {
                Gizmos.DrawLine(PathElements[i -1].position, PathElements[i].position);
            }

            if (PathType == PathTypes.loop)
            {
                Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
            }
        
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathElements == null || PathElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PathElements[MoveingTo];

            if (PathElements.Length == 1)
            {
                continue;
            }

            if (PathType == PathTypes.linear)
            {
                if (MoveingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if(MoveingTo >= PathElements.Length - 1)
                {
                    movementDirection = -1;
                }
            }

            MoveingTo = MoveingTo + movementDirection;
            if (PathType == PathTypes.loop)
            {
                if (MoveingTo >= PathElements.Length)
                {
                    MoveingTo = 0;
                }

                if (MoveingTo < 0)
                {
                    MoveingTo = PathElements.Length - 1;
                }
            }
        }
    }
}

