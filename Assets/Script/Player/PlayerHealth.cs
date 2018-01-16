using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : Destructable
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Image damageImage;
    [SerializeField] AudioClip hurtClip;
    [SerializeField] AudioClip deathClip;

    private bool damaged;

    public override void Die()
    {
        Player.Instance.PlayerAudio.clip = deathClip;
        Player.Instance.PlayerAudio.Play();

        base.Die();
    }

    public override void TakeDamage(float amount, Vector3 hitPosition)
    {
        damaged = true;

        if (Player.Instance.PlayerAudio.clip != hurtClip)
            Player.Instance.PlayerAudio.clip = hurtClip;
        Player.Instance.PlayerAudio.Play();

        base.TakeDamage(amount, hitPosition);

        healthSlider.value = HitPointsRemaining;
    }

    public void CheckDamage()
    {
        if (damaged)
            damageImage.color = new Color(1f, 0f, 0f);
        else
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, 5f * Time.deltaTime);

        damaged = false;
    }
}