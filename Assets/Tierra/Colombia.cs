using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colombia : MonoBehaviour
{
    public float force = 2; //variable para el salto de "ubicación"

    public bool mFaded = false; //bandera para el fade-in y fade-out

    public float Duration = 0.2f; //variable de tiempo de transición

    // Start is called before the first frame update
    void Start()
    {

    }

// Update is called once per frame
    public void Update()
    {
        Text miPais = GameObject.Find("miPais").GetComponent<Text>();//encontrar el "text Legacy" para cambiarlo más adelante
        Text miDescripcion = GameObject.Find("miDescripcion").GetComponent<Text>();
        Image miImagen = GameObject.Find("miImagen").GetComponent<Image>();
        Rigidbody locacion = GameObject.Find("locacion").GetComponent<Rigidbody>();


        if (Input.GetMouseButtonDown(0)) //Cada vez que se haga clic (izquierdo)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Captar el punto a donde está viendo la cámara

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.transform != null)
                {
                    imprimirColombia(hit.transform.gameObject);

                    Rigidbody rb;

                    if(rb = hit.transform.GetComponent<Rigidbody>()) // esta es asignación Y TAMBÍÉN VERIFICA SI ES NULL O NO
                    {
                        //Asigna al cuerpo rígido, el nombre del componente al que se le hizo clic
                        //Fade();
                        salto(rb);// Luego se hace saltar

                        if(hit.transform.GetComponent<Rigidbody>().name == "locacion")
                        {
                        miPais.text = "Colombia"; //cambiar el nombre a "Colombia"
                        miDescripcion.text = "Colombia es un país del extremo norte de Sudamérica. Su paisaje cuenta con bosques tropicales, las montañas de los Andes y varias plantaciones de café.";
                        miImagen.sprite = Resources.Load<Sprite>("imagenColombia2");
                        }

                        else if (hit.transform.GetComponent<Rigidbody>().name == "locacion (1)"){
                            miPais.text = "Brasil";
                            miDescripcion.text = "Brasil es un vasto país de Sudamérica que se extiende desde la Cuenca del Amazonas en el norte hasta los viñedos y las enormes cataratas del Iguazú en el sur. Río de Janeiro, simbolizado por su estatua de 38 m del Cristo Redentor sobre el cerro del Corcovado";
                            miImagen.sprite = Resources.Load<Sprite>("imagenBrasil");
                        }

                        else if (hit.transform.GetComponent<Rigidbody>().name == "locacion (2)")
                        {
                            miPais.text = "China";
                            miDescripcion.text = "China es un país soberano de Asia Oriental. Es el país más poblado del mundo, con más de 1400 millones de habitantes, y la primera potencia económica mundial por PIB en términos de paridad de poder adquisitivo.";
                            miImagen.sprite = Resources.Load<Sprite>("imagenChina");
                        }

                        //Fade();
                    }
                }
            }
        }
        
    }

    public void imprimirColombia (GameObject go) //para estar seguros de que está entrando al if del clic
    {
        print(go.name);
    }

    public void salto(Rigidbody rig) //para la animación de "ubicación"
    {
        rig.AddForce(rig.transform.up * force, ForceMode.Impulse); //lanzar con la fuerza que se asignó a la variable de más arriba
    }

    public void Fade() //método para hacer el efecto de disolver
    {
        var canvGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0)); //Llamar el método de la animación con el canvGroup, desde el alpha (como esté, ya sea 100% o 0%) hasta el que corresponda
        mFaded = !mFaded; //alternar el mFaded
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end) //método para reproducir la animación
    {
        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration); //setear el alfa de canvGroup 

            yield return null;//Como en todos los métodos que se llaman en co-rutinas
        }
    }

}
