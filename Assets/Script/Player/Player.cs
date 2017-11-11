using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[System.Serializable]
	public class MouseInput {
		public Vector2 Damping;
		public Vector2 Sensitivity;
	}

	[SerializeField]float speed;
	[SerializeField]MouseInput MouseControl;

    private static Player m_Instance;
    public static Player Instance
    {
        get
        {
            return m_Instance;
        }
    }

    private PlayerMovement m_PlayerMovement;
	public PlayerMovement PlayerMovement
    {
		get{
			if(m_PlayerMovement == null)
                m_PlayerMovement = GetComponent<PlayerMovement>();
			return m_PlayerMovement;
		}
	}

    private Crosshair m_Crosshair;
    private Crosshair Crosshair
    {
        get
        {
            if (m_Crosshair == null)
                m_Crosshair = GetComponentInChildren<Crosshair>();
            return m_Crosshair;
        }
    }

    private PlayerHealth m_PlayerHealth;
    public PlayerHealth PlayerHealth
    {
        get
        {
            if (m_PlayerHealth == null)
                m_PlayerHealth = GetComponent<PlayerHealth>();
            return m_PlayerHealth;
        }
    }

    private PlayerShoot m_PlayerShoot;
    public PlayerShoot PlayerShoot
    {
        get
        {
            if (m_PlayerShoot == null)
                m_PlayerShoot = GetComponent<PlayerShoot>();
            return m_PlayerShoot;
        }
    }


    private AudioSource m_PlayerAudio;
    public AudioSource PlayerAudio
    {
        get
        {
            if (m_PlayerAudio == null)
                m_PlayerAudio = GetComponent<AudioSource>();
            return m_PlayerAudio;
        }
    }

    InputController playerInput;
	Vector2 mouseInput;

	void Awake () {
        m_Instance = this;

		playerInput = GameManager.Instance.InputController;
		GameManager.Instance.LocalPlayer = this;
	}
	
	void Update () {
		Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        PlayerMovement.Move(direction);

		mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

        Crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);

        PlayerShoot.Shoot(GameManager.Instance.InputController.Fire1);

        PlayerHealth.CheckDamage();
    }
}
