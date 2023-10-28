using System.Collections;
using UnityEngine;

public class StartCin : MonoBehaviour
{
    public Animator animator;
    public GameObject objetoHijo;
    public GameObject jugador;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(EsperarYCambiarEstado());
    }

    IEnumerator EsperarYCambiarEstado()
    {
        animator.Play(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        Destroy(objetoHijo);

        jugador.SetActive(true);
    }
}
