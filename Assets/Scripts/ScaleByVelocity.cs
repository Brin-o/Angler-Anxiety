using UnityEngine;
using DG.Tweening;
public class ScaleByVelocity : MonoBehaviour
{
	public enum Axis { X, Y }

	public float bias = 1f;
	public float strength = 1f;
	public Axis axis = Axis.Y;

	public new Rigidbody2D rigidbody;
	[Range(0, 1)]
	public float velocityGate = 0.2f;
	[SerializeField] float tweenTimer = 0.5f;
	[SerializeField] float slowTweenTimer = 0.1f;
	[SerializeField] float yScaleLimit = 1.2f;
	[SerializeField] float xScaleLimit = 1.1f;


	private Vector2 startScale;
	private Vector3 targetTween;
	private Vector3 originalScale;

	private void Start ()
	{
		startScale = transform.localScale;
		originalScale = transform.localScale;
		
	}

	private void FixedUpdate ()
	{
		var velocity = rigidbody.velocity.magnitude;

		//if (Mathf.Approximately (velocity, 0f))
		if (velocity < velocityGate)
			transform.DOScale(originalScale, slowTweenTimer);
			//TODO: Ko se speeda up hočem animacijo potegnit iz 1,1 v karkoli bi moralo biti

		var amount = velocity * strength + bias;
		var inverseAmount = (1f / amount) * startScale.magnitude;


		if (velocity > velocityGate)
		{
		
			if (inverseAmount > yScaleLimit)
				inverseAmount = yScaleLimit;
			if (amount > xScaleLimit)
				amount = xScaleLimit;
			
			switch (axis)
			{
				case Axis.X:
					targetTween = new Vector3 (amount, inverseAmount, transform.rotation.eulerAngles.z);
					transform.DOScale(targetTween,tweenTimer);
					return;
				case Axis.Y:
					targetTween = new Vector3 (inverseAmount, amount, transform.rotation.eulerAngles.z);
					transform.DOScale(targetTween,tweenTimer);
					return;
			}
		}
		
	}
}