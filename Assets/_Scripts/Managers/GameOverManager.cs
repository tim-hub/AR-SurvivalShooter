using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restrtDelay=5f;


    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

			restartTimer+=Time.deltaTime;

			if(restartTimer>=restrtDelay){
			
				Application.LoadLevel(Application.loadedLevel);
			}

        }
    }
}
