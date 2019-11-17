using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController> {

    Rigidbody2D player; // Joueur
    SpriteRenderer playerRenderer;
    float move; // Vitesse du joueur
    bool facingRight = true; // Regarde à droite par défaut
    public float playerMaxSpeed; // Vitesse max du joueur
    Animator playerAnim; // Composant animator

    bool grounded = true; // Est au sol par défaut
    float groundCheckRadius = 0.1f; // Rayon du cercle qui teste le contact du joueur avec le sol
    public LayerMask groundLayer; // Référence au layer Ground
    public Transform groundCheck; // Référence à l'objet GroundCheckLocation
    public float jumpPower; // Force avec laquelle le joueur sera projeté en l'air lors du saut

    bool isOnLadder; // Le joueur est-il sur l'échelle ?

    // Use this for initialization
    void Start () {

        Time.timeScale = 1;

        // Récupération des composants
        player = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (grounded && Input.GetAxis("Jump") > 0)
        {
            playerAnim.SetBool("isGrounded", false); // Le joeur n'est plus au sol
            player.velocity = new Vector2(player.velocity.x, 0f);
            player.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            grounded = false;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        playerAnim.SetBool("isGrounded", grounded);

        if (isOnLadder && Input.GetAxis("Vertical") > 0)
        {
            move = Input.GetAxis("Vertical");
            player.velocity = new Vector2(player.velocity.x, move * playerMaxSpeed); // Montée à l'échelle
        }
        else
        {
            move = Input.GetAxis("Horizontal");
            player.velocity = new Vector2(move * playerMaxSpeed, player.velocity.y);
        }
            

        playerAnim.SetFloat("moveSpeed", Mathf.Abs(move)); // Stocke la valeur de la variable move dans la variable MoveSpeed

        if ((move < 0 && facingRight) || (move > 0 && !facingRight))
            Flip();

	}

    void Flip()
    {
        facingRight = !facingRight;
        playerRenderer.flipX = !playerRenderer.flipX;
    }

    public void MoveOnLadder(bool input)
    {
        isOnLadder = input;
    }

    public void Teleport(float x, float y, float scale)
    {
        if (move < 0)
            player.transform.position = new Vector2(x - scale , y);
        else
            player.transform.position = new Vector2(x + scale, y);
    }


    // Fait gagner le joueur
    public void MakeWin()
    {
        UIManager.Instance.EndGame(true);
    }

    // Mise à mort
    public void MakeDead()
    {
        UIManager.Instance.EndGame(false);
        Destroy(gameObject); // Détruit le gameObject courrant (ici le joueur)
    }

}
