using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	//Dieses Skript sorgt für die Anpassung der Sprungkraft und das Spiegeln des Spielers, sobald er die Richtung ändert
	//SerializeFields habe ich erstellt, damit ich in Unity private Werte ändern kann, ohne das Skript zu öffnen

	[SerializeField] private float m_JumpForce = 400f;							// Sprungkraft
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// Zu welchem Grad ist die Bewegung "smooth"
	[SerializeField] private LayerMask m_WhatIsGround;							// Eine mask die bestimmt, was Boden für den Charakter ist
	[SerializeField] private Transform m_GroundCheck;							// An dieser Position wird überprüft, ob der Player auf dem Boden ist oder nicht

	const float k_GroundedRadius = .2f; // Radius des overlap circles, der festlegt, ob Player am Boden ist
	private bool m_Grounded;            // Gibt an, ob der Spieler auf dem Boden ist oder nicht

	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // Um festzustellen in welcher Richtung der Player zeigt
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")] // für den Inspector
	[Space]			  //  für den Inspector

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>(); // initialisiere Rigidbody2D

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();		//Rufe OnLandEvent auf
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded; // true-Wert wird gespeichert
		m_Grounded = false;

		// Spieler ist auf dem Boden, wenn ein Kreis um den Groundcheck mit etwas kollidiert, dass als Boden festgelegt ist (wird in Engine bei What Is Ground festgelegt)
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround); //(m_GroundCheck.position ist Mittelpunkt des Kreises
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	//Bewegungsphysik auf dem Boden und in der Luft
	public void Move(float move,  bool jump)
	{
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);// Berechne Zielgeschwindigkeitsvektor des Players
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing); // gradueller �bergang zum Zielgeschwindigkeitsvektor

			// Wenn der Input eine Rechtsbewegung ist und der Player links gerichtet ist, spiegel den Sprite 
			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}
			//Und umgekehrt
			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
		
		// Wenn der Player auf dem Boden ist und springt, übe eine vertikale Kraft auf ihn aus
		if (m_Grounded && jump)
		{	 
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce)); // 
		}
	}


	private void Flip()
	{
		//ändere den boolschen Wert bei der Richtungsänderung
		m_FacingRight = !m_FacingRight;

		// Multipliziere die x-Skalierung mit -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	public void FaceRight()
    {
		//Wenn sich der boolsche Wert von m_FacingRight ändert, spiegel den Sprite
		//Wenn sich der boolsche Wert von m_FacingRight ändert, spiegel den Sprite
        if (!m_FacingRight)
        {
			Flip();
        }
    }
}