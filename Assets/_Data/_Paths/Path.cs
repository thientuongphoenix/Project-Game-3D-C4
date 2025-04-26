using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Path : SaiMonoBehaviour
{
    [SerializeField] protected List<Point> points = new();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoints();
    }

    public virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform child in transform)
        {
            Point point = child.GetComponent<Point>();
            this.points.Add(point);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }
}
