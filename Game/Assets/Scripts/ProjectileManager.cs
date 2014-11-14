using UnityEngine;
using System.Collections;

public class ProjectileManager : ScriptableObject
{
	private GameObject projectile;
	private int id;
	private DirectionEnum direction;
	private Element element;
	private Vector3 position;
	private bool destroyed;

	public ProjectileManager(GameObject projectile, int id, DirectionEnum direction, Element element, Vector3 position)
	{
		this.projectile = projectile;
		this.id = id;
		this.direction = direction;
		this.element = element;
		this.position = position;
		destroyed = false;
	}

	public GameObject GetProjectile()
	{
		return this.projectile;
	}

	public bool GetDestroyed()
	{
		return this.destroyed;
	}

	public DirectionEnum GetDirection()
	{
		return this.direction;
	}

	public Element GetElement()
	{
		return this.element;
	}

	public Vector3 GetPosition()
	{
		return this.position;
	}

	public void SetPosition(Vector3 position)
	{
		this.position = position;
		projectile.transform.position = position;
	}

	public void DestroyObject()
	{
		if (this.projectile != null)
		{
			Destroy(this.projectile);
			this.projectile = null;
			destroyed = true;
		}
	}
}
