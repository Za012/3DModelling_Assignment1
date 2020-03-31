using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    public float gravity = -19.62f;
    public float jumpHeight = 1.5f;


    public Vector3 velocity;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Walk()
    {
        velocity.x = Input.GetAxis("Horizontal") * speed;
        velocity.z = Input.GetAxis("Vertical") * speed;

        rb.velocity = velocity;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.UnloadSceneAsync("Level" + Game.CURRENTLEVEL);
            SceneManager.LoadScene("Level" + Game.CURRENTLEVEL, LoadSceneMode.Additive);
        }
        if (velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Walk();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isGrounded = false;
        }

        velocity.y += gravity * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        if (collision.gameObject.layer == LayerMask.NameToLayer("GoalPlate"))
        {
            StartCoroutine(LevelComplete());
        }
    }

    private IEnumerator LevelComplete()
    {
        Game.UI.ChangeAnnouncementText("Level Complete!", 2);
        // Win announcement
        yield return new WaitForSeconds(2);
        // Load next scene
        int levelId = Game.CURRENTLEVEL;
        //SceneManager.UnloadSceneAsync("Level"+Game.CURRENTLEVEL);
        if (levelId < SceneManager.sceneCountInBuildSettings -2)
        {
            SceneManager.UnloadSceneAsync("Level" + levelId);
            levelId += 1;
            SceneManager.LoadScene("Level" + levelId, LoadSceneMode.Additive);
        }
        else
        {
            Game.UI.ChangeAnnouncementText("Thanks for playing \n You win!!");
        }
    }
}

