using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public static PlayerShooting instance=null;

	public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

	public bool shooting=false;


    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
		if(instance==null){
			instance=this;
		}else if(instance!=this){
			Destroy(gameObject);
		}

        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

#if UNITY_EDITOR
//		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
//        {
//            Shoot ();
//        }

#endif
		if(shooting && timer >= timeBetweenBullets && Time.timeScale != 0){
			Shoot();
		}



        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }


    }
	public void StartShooting(){

		shooting=true;
	}
	public void EndShooting(){

		shooting=false;
	}


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    public void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
