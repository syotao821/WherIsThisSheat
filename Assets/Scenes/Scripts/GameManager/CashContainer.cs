using UnityEngine;

public struct CashContainer
{
	float _timeDalta;
	Vector3 _vecUp;
	Vector3 _vecDown;
	Vector3 _vecLeft;
	Vector3 _vecRight;
	Vector3 _vecFoward;
	Vector3 _vecFront;

	public float TimeDalta { get => _timeDalta; set => _timeDalta = value; }
	public Vector3 VecUp { get => _vecUp; set => _vecUp = value; }
	public Vector3 VecDown { get => _vecDown; set => _vecDown = value; }
	public Vector3 VecLeft { get => _vecLeft; set => _vecLeft = value; }
	public Vector3 VecRight { get => _vecRight; set => _vecRight = value; }
	public Vector3 VecFoward { get => _vecFoward; set => _vecFoward = value; }
	public Vector3 VecFront { get => _vecFront; set => _vecFront = value; }
}