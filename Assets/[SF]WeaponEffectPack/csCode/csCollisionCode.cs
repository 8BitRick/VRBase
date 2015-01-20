using UnityEngine;
using System.Collections;

public class csCollisionCode : MonoBehaviour {

    public csProjectileCode Code; //Parent Object Code.
    public string[] Tag = new string[1]; //For Collider Check Tag.
    public bool OnMove = true; //Move Check
    public bool isExplosion; //Explosion Check
    public bool isDestroy; //Destroy Check
    public bool isRaycastHit; //if you want use Raycast Colision Check, Check this.
    public bool isAnimationPlay;
    public float MaxLength; //MaxLength Set
    public float Speed = 60;
    bool isExplosionPlayed = true; // is Check Explosion is provoke when you use Raycast. 
    public bool isFlame=true; // Flame Thrower Check
    [HideInInspector]
    public bool Flaming = true; // Check Flaming
    [HideInInspector]
    public Transform FlameParticle; //This is For inherit to Parent Object
    [HideInInspector]
    public Transform FlameParticle2; //This is For Collision Object
    public string FireName; // For Check the FireEmission name in the Hitted Object.
	Vector3 Velocity = Vector3.zero;

    void FixedUpdate()
    {

        if (OnMove)
        {
            if (Code.isRigidBody) // if Parents code isRigidBody is true, execute this.
            {
                Velocity = (Code.rigidbody.rotation * Vector3.forward) * (Speed);
                Code.rigidbody.velocity = Vector3.Lerp(Code.rigidbody.velocity, Velocity, Time.fixedDeltaTime);
            }
        }
    }

    void Update()
    {
        if (OnMove)
        {
            if (!Code.isRigidBody) // if Parents code isRigidBody is false, execute this.
                Code.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }


        if (isAnimationPlay)
            animation.Play(); // usually, use this to check flame object Collision.

        if (isFlame)
        {
            if (Flaming == false) // if Flaming is False FlameParticle2 Change null
            {
                FlameParticle2 = null;
            }

            if (FlameParticle2 != null) // if Flaming is Ture and FlameParticle2 is not null, execute this 'if' function 
            {
                if (FlameParticle2.FindChild(FireName)) // Find "Fire"name in the FlameParticle2 Object.
                {
                    Transform Finds = FlameParticle2.FindChild(FireName).transform; //Set Fire Value to Finds Value becuase of Hitted object's Plame Emission
                    csFlameCollider Fc = (csFlameCollider)Finds.GetComponent("csFlameCollider"); //Change "csFlameCollider" Code
                    Fc.delay = 5; // keep emitting
                }
            }
        }

        if (isRaycastHit) //this is execute when you check the isRaycastHit
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, MaxLength))
            {
                for (int i = 0; i < Tag.Length; i++) // Tag Length Check.
                {
                    if (hit.collider.tag == Tag[i]) // Collider Tag Check.
                    {
                        if (isExplosionPlayed) // for one execute Explosion
                        {
                            isExplosionPlayed = false;
                            Code.MakeExplosion(hit.point, hit.collider.transform.rotation);
                            // Quick hack to make physics work when we hit something
                            if(hit.collider.rigidbody != null)
                                hit.collider.rigidbody.AddExplosionForce(10.0f, hit.point, 10.0f, 0.0f, ForceMode.Impulse);
                            GameObject ls = GameObject.Find("LaserShot");
                            LaserShot lss = ls.GetComponent<LaserShot>();
                            lss.transform.position = hit.point;
                            lss.explosionSoundSource.Play();
                        }
                        Code.DestroyObj();
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider Object)
    {
        //this is execute when you don't check the isRaycastHit
        if (!isRaycastHit)
        {
            if (Tag.Length >= 1)
            {
                for (int i = 0; i < Tag.Length; i++)
                {
                    if (Object.tag == Tag[i])
                        HitFunction(Object);
                }
            }
            else
                HitFunction(Object);
        }
    }

    private void OnTriggerStay(Collider Object) //Functioning isFlame is true
    {
        if (isFlame)
        {
            FlameParticle2 = Object.transform;
        }
    }

    private void OnTriggerExit(Collider Object) //Functioning isFlame is true
    {
        if (isFlame)
        {
            FlameParticle2 = null;
        }
    }

    void HitFunction(Collider Object)
    {
        if (isExplosion)
            Code.MakeExplosion();
        if (OnMove)
		{
			Speed = 0;
            OnMove = false;
		}
        if (isDestroy)
            Code.DestroyObj();
        if (isFlame)
        {
            if (!(Object.transform.FindChild(FireName)))
            {
                FlameParticle2 = Object.transform;
                FlameParticle = Code.Flame(Object,FireName); // send Object Information and FireEmission Name
                FlameParticle.parent = Object.transform;
            }
        }
    }
}
